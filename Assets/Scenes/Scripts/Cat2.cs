using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Cat2 : NetworkBehaviour
{

    public string direction = "right";
    public Movement movement;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private bool isTouchMove = false;

    public void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        if (this.isLocalPlayer)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                currentPosition = Input.GetTouch(0).position;
                Vector2 Distance = currentPosition - startTouchPosition;

                if (!isTouchMove)
                {
                    if (Distance.y > 0)
                    {
                        Debug.Log("Move Up");
                        this.movement.SetDirection(Vector2.up);
                        isTouchMove = true;
                    }
                    else if (Distance.y < 0)
                    {
                        Debug.Log("Move Down");
                        this.movement.SetDirection(Vector2.down);
                        isTouchMove = true;
                    }
                    else if (Distance.x < 0)
                    {
                        Debug.Log("Move Left");
                        if (direction == "right")
                        {
                            this.transform.Rotate(Vector3.up * 180);
                            direction = "left";
                        }
                        this.movement.SetDirection(Vector2.left);
                        isTouchMove = true;
                    }
                    else if (Distance.x > 0)
                    {
                        Debug.Log("Move Right");
                        if (direction == "left")
                        {
                            this.transform.Rotate(Vector3.up * 180);
                            direction = "right";
                        }
                        this.movement.SetDirection(Vector2.right);
                        isTouchMove = true;
                    }
                }
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                isTouchMove = false;
            }


            if (Input.GetKeyDown(KeyCode.W))
            {
                this.movement.SetDirection(Vector2.up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                this.movement.SetDirection(Vector2.down);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (direction == "right")
                {
                    this.transform.Rotate(Vector3.up * 180);
                    direction = "left";
                }
                this.movement.SetDirection(Vector2.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (direction == "left")
                {
                    this.transform.Rotate(Vector3.up * 180);
                    direction = "right";
                }
                this.movement.SetDirection(Vector2.right);
            }
        }
    }
    public void MoveUp()
    {
        this.movement.SetDirection(Vector2.up);
    }

    public void MoveDown()
    {
        this.movement.SetDirection(Vector2.down);
    }

    public void MoveLeft()
    {
        if (direction == "right")
        {
            this.transform.Rotate(Vector3.up * 180);
            direction = "left";
        }
        this.movement.SetDirection(Vector2.left);
    }

    public void MoveRight()
    {
        if (direction == "left")
        {
            this.transform.Rotate(Vector3.up * 180);
            direction = "right";
        }
        this.movement.SetDirection(Vector2.right);
    }
}