using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioListenerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.audioListener)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAudioListener(bool isOn)
    {
        if (isOn)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    public void SetTimeScale(int value)
    {
        Time.timeScale = value;
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
