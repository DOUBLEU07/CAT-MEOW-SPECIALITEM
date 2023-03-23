using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public string[] dogs_array = { "Dog_Red(Clone)", "Dog_Blue(Clone)", "Dog_Green(Clone)", "Dog_Yellow(Clone)" };
    public Transform foods;
    public CatEnergy catEnergy;
    public Text Score_txt;
    public int score;
    public GameObject network_UI;
    private Dog dogs;
    private GameObject catobj;
    private GameObject dogobj;
    public Dictionary<string, int> playerLives = new Dictionary<string, int>() {
        {"Cat(Clone)", 3},
        {"Cat2(Clone)", 3}
    };

    private void Start()
    {
        network_UI.SetActive(true);
        NewGame();
    }

    public void NewGame()
    {
        score = 0;
    }

    private void Case(string casename)
    {
        if (casename == "win")
        {
            SceneManager.LoadScene(4);
        }
        else if (casename == "lose")
        {
            SceneManager.LoadScene(5);
        }
    }

    private void GameOver()
    {
        for (int i = 0; i < this.dogs_array.Length; i++)
        {
            string name = dogs_array[i];
            this.dogobj = GameObject.Find(name);
            this.dogobj.gameObject.SetActive(false);
        }
        catobj.gameObject.SetActive(false);
        score = 0;
        SetScore();
        playerLives["Cat1(Clone)"] = 3;
        playerLives["Cat2(Clone)"] = 3;
        Case("lose");
    }

    public void IncreaseScore(int scores)
    {
        this.score += scores;
    }

    private void SetScore()
    {
        Score_txt.text = "Score : " + this.score;
    }

    public void DecreaseLives(int lives,string name)
    {
        if (name == "Cat(Clone)")
        {
            playerLives["Cat(Clone)"] = playerLives["Cat(Clone)"] - lives;
        }
        else if (name == "Cat2(Clone)")
        {
            playerLives["Cat2(Clone)"] = playerLives["Cat2(Clone)"] - lives;
        }
    }

    public void DogEaten(Dog dog)
    {
        SoundManager.PlaySound("DogDied");
        dog.gameObject.SetActive(false);
        IncreaseScore(200);
        SetScore();
        dogs = dog;
        RespawnDog();
    }

    public void CatEaten(string name)
    {
        SoundManager.PlaySound("CatDied");
        DecreaseLives(1, name);
        if (name == "Cat(Clone)")
        {
            catobj = GameObject.Find("Cat(Clone)");
            catobj.gameObject.SetActive(false);
            if (playerLives["Cat(Clone)"] > 0)
            {
                Invoke("RespawnCat", 0.1f);
            }
        }
        if (name == "Cat2(Clone)")
        {
            catobj = GameObject.Find("Cat2(Clone)");
            catobj.gameObject.SetActive(false);
            if (playerLives["Cat2(Clone)"] > 0)
            {
                Invoke("RespawnCat", 0.1f) ;
            }
        }

        if(playerLives["Cat(Clone)"] <= 0 || playerLives["Cat2(Clone)"] <= 0)
        {
            GameOver();
        }
    }

    public void NormalFoodEaten(NormalFood normal_food)
    {
        Debug.Log(normal_food);
        normal_food.gameObject.SetActive(false);
        IncreaseScore(normal_food.points);
        SetScore();

        if (CheckingAllFoods())
        {
            SoundManager.PlaySound("Victory");
            Case("win");
        }
    }

    public void SpecialEaten(SpecialItem normal_food)
    {
        Debug.Log(normal_food);
        normal_food.gameObject.SetActive(false);
        IncreaseScore(normal_food.points);
        SetScore();

        if (CheckingAllFoods())
        {
            SoundManager.PlaySound("Victory");
            Case("win");
        }
    }

    public void CatEnergyEaten()
    {
        catEnergy.energyEaten = true;
        Invoke("ResetEnergy", 8.0f);
    }

    private bool CheckingAllFoods()
    {
        foreach (Transform foods in this.foods)
        {
            if (foods.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    public void ResetEnergy()
    {
        catEnergy.energyEaten = false;
    }

    private void RespawnDog()
    {
        if (dogs.gameObject.name == "Dog_Red(Clone)")
        {
            dogs.transform.position = new Vector3(-12.5f, 14.42f, -5f);
        }
        else if (dogs.gameObject.name == "Dog_Green(Clone)")
        {
            dogs.transform.position = new Vector3(-12.5f, -14.46f, -5f);
        }
        else if (dogs.gameObject.name == "Dog_Blue(Clone)")
        {
            dogs.transform.position = new Vector3(10.9f, 14.42f, -5f);
        }
        else if (dogs.gameObject.name == "Dog_Yellow(Clone)")
        {
            dogs.transform.position = new Vector3(10.9f, -14.46f, -5f);
        }
        dogs.gameObject.SetActive(true);
    }

   private void RespawnCat()
    {
        catobj.transform.position = new Vector3(-0.37f, -0.72f, -5f);
        catobj.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
}

