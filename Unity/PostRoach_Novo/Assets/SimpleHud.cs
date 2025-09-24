using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleHud : MonoBehaviour
{
    [SerializeField] GameObject derrota;

    [Header("Configuração inicial")]
    public static int totalCartas;
    public static int cartasEntregues;
    [SerializeField] float tempoBase = 60f;
    [SerializeField] float bonusInicialPorCarta = 10f;
    [SerializeField] float bonusPorEntrega = 10f;
    [SerializeField] bool countdown = true;

    [Header("Aparência")]
    [SerializeField] Color painel = new Color(0,0,0,0.45f);
    [SerializeField] Color texto = Color.white;
    [SerializeField] Font fonteCustom;   // arraste uma .ttf REGULAR (não-variable)
    [SerializeField] bool logDebug = true;

    Text txtCartas, txtTimer;
    float tempoSeg;

    void Awake()
    {
        totalCartas = Random.Range(6, 21);

        derrota.SetActive(false);

        // EventSystem
        if (FindObjectOfType<EventSystem>() == null)
            new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));

        // Canvas
        var canvasGO = new GameObject("HUD_Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        var canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        var scaler = canvasGO.GetComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(2340, 1080);
        scaler.matchWidthOrHeight = 1f;

        // Cartas (topo-esquerda) — maior
        var cartasPanel = CreatePanel(canvas.transform, new Vector2(0,1), new Vector2(0,1),
                                      new Vector2(0,1), new Vector2(220,70), new Vector2(30,-30));
        txtCartas = CreateText(cartasPanel, TextAnchor.MiddleLeft, 40, new Vector2(15,0));

        // Timer (topo-centro) — maior
        var timerPanel = CreatePanel(canvas.transform, new Vector2(0.5f,1), new Vector2(0.5f,1),
                                     new Vector2(0.5f,1), new Vector2(200,70), new Vector2(0,-30));
        txtTimer = CreateText(timerPanel, TextAnchor.MiddleCenter, 40, Vector2.zero);

        // Tempo inicial e textos
        tempoSeg = Mathf.Max(0f, tempoBase) + Mathf.Max(0, totalCartas) * Mathf.Max(0f, bonusInicialPorCarta);
        AtualizarCartas();
        AtualizarTimer();
    }

    void Update()
    {
        if (countdown) tempoSeg = Mathf.Max(0f, tempoSeg - Time.deltaTime);
        else tempoSeg += Time.deltaTime;
        AtualizarTimer();
        txtCartas.text = $"{cartasEntregues}/{Mathf.Max(totalCartas, 0)}";
    }

    // -------- API --------
    public void Configurar(int total, float baseSeg, float bonusInicial, float bonusEntrega, bool contaPraBaixo = true)
    {
        totalCartas = Mathf.Max(0, total);
        tempoBase = Mathf.Max(0f, baseSeg);
        bonusInicialPorCarta = Mathf.Max(0f, bonusInicial);
        bonusPorEntrega = Mathf.Max(0f, bonusEntrega);
        countdown = contaPraBaixo;

        //cartasEntregues = 0;
        tempoSeg = tempoBase + totalCartas * bonusInicialPorCarta;
        AtualizarCartas();
        AtualizarTimer();
    }

    /*public void SetCartas(int entregues, int total)
    {
        cartasEntregues = Mathf.Clamp(entregues, 0, Mathf.Max(total, 0));
        totalCartas = Mathf.Max(0, total);
        AtualizarCartas();
    }

    public void EntregouCarta()
    {
        cartasEntregues = Mathf.Clamp(cartasEntregues + 1, 0, Mathf.Max(totalCartas, 1));
        tempoSeg += Mathf.Max(0f, bonusPorEntrega);
        //AtualizarCartas();
        AtualizarTimer();
    }*/
    
    // -------- helpers --------
    RectTransform CreatePanel(Transform parent, Vector2 aMin, Vector2 aMax, Vector2 pivot, Vector2 size, Vector2 anchored)
    {
        var rt = new GameObject("Panel", typeof(RectTransform), typeof(Image)).GetComponent<RectTransform>();
        rt.SetParent(parent, false);
        rt.anchorMin = aMin; rt.anchorMax = aMax; rt.pivot = pivot;
        rt.sizeDelta = size; rt.anchoredPosition = anchored;
        rt.GetComponent<Image>().color = painel;
        return rt;
    }

    Text CreateText(RectTransform parent, TextAnchor align, int fontSize, Vector2 offset)
    {
        var go = new GameObject("Text", typeof(RectTransform), typeof(Text));
        var rt = go.GetComponent<RectTransform>();
        rt.SetParent(parent, false);
        rt.anchorMin = Vector2.zero; rt.anchorMax = Vector2.one; rt.pivot = new Vector2(0.5f,0.5f);
        rt.offsetMin = new Vector2(8 + offset.x, 4 + offset.y);
        rt.offsetMax = new Vector2(-8 + offset.x, -4 + offset.y);

        var t = go.GetComponent<Text>();
        var f = PickFont();
        if (f != null)
        {
            t.font = f;
            if (f.material != null) t.material = f.material;
        }
        t.fontSize = fontSize;
        t.alignment = align;
        t.color = texto;
        t.supportRichText = false;
        t.resizeTextForBestFit = false;
        t.horizontalOverflow = HorizontalWrapMode.Overflow;
        t.verticalOverflow = VerticalWrapMode.Overflow;
        t.text = "";
        return t;
    }

    Font PickFont()
    {
        if (fonteCustom != null) return fonteCustom;
        if (logDebug) Debug.LogWarning("SimpleHud: nenhuma fonte definida. Arraste uma .ttf REGULAR em 'Fonte Custom'.");
        return null;
    }

    void AtualizarCartas()
    {
       
    }

    void  AtualizarTimer()
    {
        if (!txtTimer) return;
        int m = Mathf.FloorToInt(tempoSeg / 60f);
        int s = Mathf.FloorToInt(tempoSeg % 60f);
        txtTimer.text = $"{m:00}:{s:00}";

        if(m == 0 && s == 0 && cartasEntregues < totalCartas)
        {
            Derrota();
        }
    }

    void Derrota()
    {
        Time.timeScale = 0;
        derrota.SetActive(true);
    }
}
