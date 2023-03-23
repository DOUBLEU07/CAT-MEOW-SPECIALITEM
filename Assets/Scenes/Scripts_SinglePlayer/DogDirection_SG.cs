using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDirection_SG : MonoBehaviour
{
    public string direction = "left";
    public Movement_SG movement { get; private set; }
    void Awake()
    {
        this.movement = GetComponentInParent<Movement_SG>();
    }

    void Update()
    {
        if (this.movement.direction == Vector2.left)
        {
            if (direction == "right")
            {
                this.transform.Rotate(Vector3.up * 180);
                direction = "left";
            }
        }
        else if (this.movement.direction == Vector2.right)
        {
            if (direction == "left")
            {
                this.transform.Rotate(Vector3.up * 180);
                direction = "right";
            }
        }
    }
}
