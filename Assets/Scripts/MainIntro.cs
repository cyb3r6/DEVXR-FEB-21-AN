using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainIntro : MonoBehaviour
{
    public Button vRButton;

    public Button quitButton;

    private void Awake()
    {
        vRButton.onClick.AddListener(LaunchVRScene);

    }

    public void LaunchVRScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
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

