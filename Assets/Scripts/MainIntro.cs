using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainIntro : MonoBehaviour
{
    public void LaunchScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void LaunchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


    public void QuitApp()
    {
        Application.Quit();
    }
}

