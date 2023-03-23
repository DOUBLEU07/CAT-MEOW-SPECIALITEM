using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class StartMenuTests
{
    [Test]
    public void test_playbtn_onClick()
    {
        GameObject gameObject = new GameObject();
        StartMenu startMenu = gameObject.AddComponent<StartMenu>();
        startMenu.PlayGame(0);
        Assert.AreEqual("SinglePlayer", startMenu.sceneName);
    }

    [Test]
    public void test_multiplayerbtn_onClick()
    {
        GameObject gameObject = new GameObject();
        StartMenu startMenu = gameObject.AddComponent<StartMenu>();
        startMenu.PlayMultiplayer(0);
        Assert.AreEqual("MultiplayerScene", startMenu.sceneName);
    }

    [Test]
    public void test_backbtn_onClick()
    {
        GameObject gameObject = new GameObject();
        StartMenu startMenu = gameObject.AddComponent<StartMenu>();
        startMenu.MultiBackToStartMenu(2);
        Assert.AreEqual("StartMenu", startMenu.sceneName);
    }
}
