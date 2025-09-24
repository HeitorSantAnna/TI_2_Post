using UnityEngine;

public class TempoVida : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
