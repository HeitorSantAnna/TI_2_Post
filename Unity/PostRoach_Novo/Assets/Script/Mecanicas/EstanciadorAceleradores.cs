using UnityEngine;

public class EstanciadorAceleradores : MonoBehaviour
{
    [SerializeField] float time = 3, delay = 2;

    [SerializeField] GameObject[] powerUps;

    void Start()
    {
        time = Random.Range(2, 7);
        delay = Random.Range(2, 9);
        InvokeRepeating("Ups", time, delay);
    }

    void Update()
    {
        
    }

    void Ups()
    {
        int random = Random.Range(0, 2);
        float localx = Random.Range(-449f, 446f);
        float localz = Random.Range(-475.8f, 473);
        //float localy = Random.Range(0.22f, 32.75f);

        Vector3 local = new Vector3(localx, 0.5f, localz);

        if (random == 1)
        {
            Instantiate(powerUps[0], local, transform.rotation);
        }
        else if(random == 0)
        {
            Instantiate(powerUps[1], local, transform.rotation);
        }

        time = Random.Range(2, 7);
        delay = Random.Range(2, 9);
    }
}
