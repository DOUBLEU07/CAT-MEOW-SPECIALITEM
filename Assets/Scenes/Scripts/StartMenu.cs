using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string sceneName = "";

    public void PlayGame(int scene)
    {
        SceneManager.LoadScene(scene + 1);
        this.sceneName = "SinglePlayer";
    }
    public void PlayMultiplayer(int scene)
    {
        SceneManager.LoadScene(scene + 2);
        this.sceneName = "MultiplayerScene";
    }
    public void MultiBackToStartMenu(int scene)
    {
        SceneManager.LoadScene(scene - 2);
        this.sceneName = "StartMenu";
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}