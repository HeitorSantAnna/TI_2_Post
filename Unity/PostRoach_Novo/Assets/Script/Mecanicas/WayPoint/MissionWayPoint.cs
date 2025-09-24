using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionWayPoint : MonoBehaviour
{
    public Image img;
    [SerializeField] Camera cam;
    public Transform target;
    public TextMeshProUGUI textMesh;
    public GameObject player, camera;

/*#if UNITY_STANDALONE_WIN
    void Start()
    {
        camera = GameObject.Find("CameraWin");
        cam = camera.GetComponent<Camera>();
        player = GameObject.Find("Player");
        cam = Camera.main;
    }
#elif UNITY_ANDROID*/

    void Start()
    {
        camera = GameObject.Find("Main Camera");
        cam = camera.GetComponent<Camera>();
        player = GameObject.Find("Player");
        cam = Camera.main;
    }

//#endif
    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = cam.WorldToScreenPoint(target.position);

        if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            // O alvo está atras do jogador
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
        textMesh.text = $"{((int)Vector3.Distance(target.position, player.transform.position)).ToString()} m";
    }
}
