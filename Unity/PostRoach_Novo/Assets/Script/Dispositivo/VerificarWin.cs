using UnityEngine;

public class VerificarWin : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    private void Awake()
    {
        gameObject.SetActive(true);
    }

#elif UNITY_ANDROID
    private void Awake()
    {
        gameObject.SetActive(false);
    }

#endif
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
