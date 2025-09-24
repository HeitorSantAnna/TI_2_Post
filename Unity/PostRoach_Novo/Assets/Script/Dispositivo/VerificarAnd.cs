using UnityEngine;

public class VerificarAnd : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    private void Awake()
    {
        gameObject.SetActive(false);
    }

#elif UNITY_ANDROID
    private void Awake()
    {
        gameObject.SetActive(true);
    }

#endif
}
