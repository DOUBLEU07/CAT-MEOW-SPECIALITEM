using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTests
{
    

    [Test]
    public void test_increase_score()
    {
        GameObject gameObject = new GameObject();
        GameManager gameManager = gameObject.AddComponent<GameManager>();
        Debug.Log(gameManager.score);

        gameManager.score = 0;

        gameManager.IncreaseScore(20);
        Assert.AreEqual(20, gameManager.score);
    }

    [Test]
    public void test_catenergy_eaten()
    {
        //GameObject gameObject_energy = new GameObject();
        //CatEnergy catEnergy = gameObject_energy.AddComponent<CatEnergy>();
        //catEnergy.energyEaten = false;

        //GameObject gameObject_gameEnergy = new GameObject();
        //GameManager gameManager = gameObject_gameEnergy.AddComponent<GameManager>();

        //gameManager.CatEnergyEaten();
        //Assert.IsTrue(catEnergy.energyEaten);
    }

    [Test]
    public void test_cat_reset_energy()
    {
        //GameObject gameObject_energy = new GameObject();
        //CatEnergy catEnergy = gameObject_energy.AddComponent<CatEnergy>();
        //catEnergy.energyEaten = true;

        //GameObject gameObject_gameEnergy = new GameObject();
        //GameManager gameManager = gameObject_gameEnergy.AddComponent<GameManager>();

        //gameManager.ResetEnergy();
        //Assert.IsFalse(catEnergy.energyEaten);
    }
}
