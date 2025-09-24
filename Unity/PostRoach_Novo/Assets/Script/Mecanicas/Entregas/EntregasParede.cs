using UnityEngine;

public class EntregasParede : MonoBehaviour
{
    public static bool entregou = false;
    public static int limite = 4;

    public GameObject pontosEntrega;

    float time = 2, delay = 2;

    void Start()
    {
        InvokeRepeating("Pontos", time, delay);
    }

    void Update()
    {
        
    }

    void Pontos()
    {
        if (limite > 0)
        {
            float localx = Random.Range(-15.8f, 15.9f);
            float localz = Random.Range(-475.8f, 473f);
            float localy = Random.Range(0.22f, 32.75f);

        
            Instantiate(pontosEntrega, transform.position = new Vector3(localx, localy, 12), transform.rotation);
            limite--;
        }
    }
}
