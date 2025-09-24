using UnityEngine;

public class RandomizadorArvores : MonoBehaviour
{
    [SerializeField] GameObject[] arvores;

    void Start()
    {
        for(int i = 0; i < 300; i++)
        {
            float rdnx = Random.Range(56.8f, 352.1f);
            float rdnz = Random.Range(73.8f, 302.9f);
            int rdnarvore = Random.Range(0, 6);

            Instantiate(arvores[rdnarvore], transform.position = new Vector3(rdnx, 0.53f, rdnz), transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
