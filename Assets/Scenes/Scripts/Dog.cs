using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Dog : NetworkBehaviour
{
    public int duration;
    public int points = 200;
    public GameManager gameManager;
    public CatEnergy catEnergy;
    public Transform target;
    public Movement movement;

    public GameObject FirstAnimation;
    public GameObject SecondAnimation;
    public GameObject FirstMinimapIcon;
    public GameObject SecondMinimapIcon;

    public Dog dog { get; private set; }

    private void Awake()
    {
        this.dog = GetComponent<Dog>();
        this.movement = GetComponent<Movement>();
        StartCoroutine(DogStartMovement());
    }

    void Update()
    {
        if (catEnergy.energyEaten)
        {
            this.FirstAnimation.SetActive(false);
            this.SecondAnimation.SetActive(true);
            this.FirstMinimapIcon.SetActive(false);
            this.SecondMinimapIcon.SetActive(true);
        }
        else
        {
            this.FirstAnimation.SetActive(true);
            this.SecondAnimation.SetActive(false);
            this.FirstMinimapIcon.SetActive(true);
            this.SecondMinimapIcon.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            if (catEnergy.energyEaten)
            {
                gameManager.DogEaten(this);
            }
            else
            {
                gameManager.CatEaten(collision.gameObject.name);
            }
        }
    }

    private IEnumerator DogStartMovement()
    {
        yield return new WaitForSeconds(duration);
        this.movement.enabled = true;
    }
}