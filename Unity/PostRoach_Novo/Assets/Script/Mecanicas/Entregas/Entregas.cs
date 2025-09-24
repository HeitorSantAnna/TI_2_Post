using UnityEngine;

public class Entregas : MonoBehaviour
{
    public static bool entregou = false;
    public static int limite;
    public static int totalentregue = 0;
    [SerializeField] AudioSource notificar;

    [SerializeField] GameObject[] pontosEntrega;
    [SerializeField] GameObject[] locaisEntrega = new GameObject[20];
    [SerializeField] bool[] locaisDisponiveis = new bool[20];

    public float time = 0, delay = 0;

    private void Awake()
    {
        for(int i = 0; i < 20; i++)
        {
            locaisDisponiveis[i] = false;
        }
    }

    void Start()
    {
        time = Random.Range(2, 7);
        delay = Random.Range(2, 9);
        limite = SimpleHud.totalCartas;
        InvokeRepeating("Pontos", time, delay);
    }

    void Update()
    {
        
    }

#if UNITY_STANDALONE_WIN
    void Pontos()
    {
        int rdnposition = Random.Range(0, 20);

        if (limite > 0 && locaisDisponiveis[rdnposition] == false)
        {
            Instantiate(pontosEntrega[0], locaisEntrega[rdnposition].transform.position, transform.rotation);
            locaisDisponiveis[rdnposition] = true;
            notificar.Play();
            limite--;
        }
        else if(locaisDisponiveis[rdnposition] == true)
        {
            Pontos();
        }

        time = Random.Range(2, 7);
        delay = Random.Range(2, 9);
    }
#elif UNITY_ANDROID

    void Pontos()
    {
        int rdnposition = Random.Range(0, 20);

        if (limite > 0 && locaisDisponiveis[rdnposition] == false)
        {
            Instantiate(pontosEntrega[1], locaisEntrega[rdnposition].transform.position, transform.rotation);
            locaisDisponiveis[rdnposition] = true;
            notificar.Play();
            limite--;
        }
        else if(locaisDisponiveis[rdnposition] == true)
        {
            Pontos();
        }

        time = Random.Range(2, 7);
        delay = Random.Range(2, 9);
    }

#endif

    /*private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Arvores"))
        {

        }
    }*/
}
