using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;

public class TitleModule : MonoBehaviour
{
    //In multiplayer page
    public void GetPlayerOne()
    {
        //GameObject.FindObjectOfType<NetworkManager>().GetComponent<TelepathyTransport>().port = 7000;
        PlayerPrefs.SetString("type", "player1");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void GetPlayerTwo()
    {
    
        PlayerPrefs.SetString("type", "player2");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

}
