using UnityEngine;

public class GameControllerSwitch : MonoBehaviour
{
    [SerializeField] Canvas[] canvasWin;
    [SerializeField] Canvas[] canvasAndroid;
    [SerializeField] GameObject[] gameObejctWin;
    [SerializeField] GameObject[] gameObjectAndroid;
    [SerializeField] bool pause = false;
    [SerializeField] GameObject gameObejctWinPause;
    [SerializeField] GameObject gameObejctAndroidPause;

#if UNITY_STANDALONE_WIN
    void Awake()
    {
        for(int i = 0; i < canvasWin.Length; i++)
        {
            canvasWin[i].enabled = true;
        }

        for(int i = 0; i < gameObejctWin.Length; i++)
        {
            gameObejctWin[i].SetActive(true);
        }

        for (int i = 0; i < gameObjectAndroid.Length; i++)
        {
            gameObjectAndroid[i].SetActive(false);
        }

        for (int i = 0; i < canvasAndroid.Length; i++)
        {
            canvasAndroid[i].enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            gameObejctWinPause.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            Time.timeScale = 1;
            pause = false;
            gameObejctWinPause.SetActive(false);
        }
    }
#elif UNITY_ANDROID
    void Awake()
    {
        for(int i = 0; i < canvasWin.Length; i++)
        {
            canvasWin[i].enabled = false;
        }

        for(int i = 0; i < canvasAndroid.Length; i++)
        {
            canvasAndroid[i].enabled = true;
        }

        for(int i = 0; i < gameObejctWin.Length; i++)
        {
            gameObejctWin[i].SetActive(false);
        }

        for (int i = 0; i < gameObjectAndroid.Length; i++)
        {
            gameObjectAndroid[i].SetActive(true);
        }
    }
#endif

    public void TruePause()
    {
        if (pause == false)
        {
            pause = true;
            Time.timeScale = 0;
            gameObejctAndroidPause.SetActive(true);
        }
        else if (pause == true)
        {
            pause = false;
            Time.timeScale = 1;
            gameObejctAndroidPause.SetActive(false);
        }
    }
}
