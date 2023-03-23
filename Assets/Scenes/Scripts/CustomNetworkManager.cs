using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject PlayerPrefab1;
    public GameObject PlayerPrefab2;

    public GameObject DogPrefab1;
    public GameObject DogPrefab2;
    public GameObject DogPrefab3;
    public GameObject DogPrefab4;

    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CharacterCreater>(OnCreateCharacter);

        GameObject Dog1 = Instantiate(DogPrefab1, new Vector3(-12.5f, 14.42f, -5f), Quaternion.identity);
        Dog dog1 = Dog1.GetComponent<Dog>();
        NetworkServer.Spawn(Dog1);

        GameObject Dog2 = Instantiate(DogPrefab2, new Vector3(-12.4f, -14.46f, -5f), Quaternion.identity);
        Dog dog2 = Dog2.GetComponent<Dog>();
        NetworkServer.Spawn(Dog2);

        GameObject Dog3 = Instantiate(DogPrefab3, new Vector3(10.9f, 14.58f, -5f), Quaternion.identity);
        Dog dog3 = Dog3.GetComponent<Dog>();
        NetworkServer.Spawn(Dog3);

        GameObject Dog4 = Instantiate(DogPrefab4, new Vector3(10.65f, -14.42f, -5f), Quaternion.identity);
        Dog dog4 = Dog4.GetComponent<Dog>();
        NetworkServer.Spawn(Dog4);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        CharacterCreater characterCreater = new CharacterCreater
        {
            character = PlayerPrefs.GetString("type")
        };
        NetworkClient.Send(characterCreater);
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, CharacterCreater message)
    {
        Debug.Log(message.character);
        if (message.character.Equals("player2"))
        {
            GameObject gameObject = Instantiate(PlayerPrefab2, new Vector3(0.65f, -0.72f, -2f), Quaternion.identity);
            Cat2 cat = gameObject.GetComponent<Cat2>();
            NetworkServer.AddPlayerForConnection(conn, gameObject);
        }
        else
        {
            GameObject gameObject = Instantiate(PlayerPrefab1, new Vector3(-1.5f, -0.72f, -2f), Quaternion.identity);
            Cat cat = gameObject.GetComponent<Cat>();
            NetworkServer.AddPlayerForConnection(conn, gameObject);
        }
    }
}