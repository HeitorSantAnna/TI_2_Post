using UnityEngine;
using UnityEngine.SceneManagement;

public class Recenhecer : MonoBehaviour
{
    string scene;

    [SerializeField] GameObject[] tutorial;

#if UNITY_STANDALONE_WIN
    public void Tutorial()
    {
        tutorial[0].SetActive(true);
    }
#elif UNITY_ANDROID
    public void Tutorial()
    {
        tutorial[1].SetActive(true);
    }
#endif
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InGameScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Sai");
    }

    public void Again(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
