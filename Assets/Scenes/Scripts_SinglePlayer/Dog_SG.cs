using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_SG : MonoBehaviour
{
    public int duration;
    public int points = 200;
    public GameManager_SG gameManager;
    public Transform target;
    public Movement_SG movement;

    public GameObject FirstAnimation;
    public GameObject SecondAnimation;
    public GameObject FirstMinimapIcon;
    public GameObject SecondMinimapIcon;

    public Dog_SG dog { get; private set; }

    private void Awake()
    {
        this.dog = GetComponent<Dog_SG>();
        this.movement = GetComponent<Movement_SG>();
        StartCoroutine(DogStartMovement());
    }

    void Update()
    {
        if (gameManager.energyEaten)
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            if (gameManager.energyEaten)
            {
                gameManager.DogEaten(this);
            }
            else
            {
                gameManager.CatEaten();
            }
        }
    }

    private IEnumerator DogStartMovement()
    {
        yield return new WaitForSeconds(duration);
        this.movement.enabled = true;
    }
}