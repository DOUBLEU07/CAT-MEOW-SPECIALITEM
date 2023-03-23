using Mirror;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkUI : NetworkManager
{
    NetworkManager manager;
    public InputField ip_Addr;
    public GameObject PlayerPrefab2;

    void Awake() {
        manager = GetComponent<NetworkManager>();
    }

    public void HostFunction()
    {
        manager.StartHost();
        Debug.Log(manager.networkAddress);

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

    }
    public void ConnectFunction()
    {
        manager.networkAddress = ip_Addr.text;
        Debug.Log(manager.networkAddress);
        manager.StartClient();

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

    }

}
