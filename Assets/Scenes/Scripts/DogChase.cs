using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChase : DogBehavior
{
    float distance1;
    float distance2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {

                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                if (GameObject.FindWithTag("Player1") == null && GameObject.FindWithTag("Player2") == null)
                {
                    if (this.distance1 < this.distance2)
                    {
                        direction = availableDirection;
                        minDistance = distance1;
                    }
                    else
                    {
                        direction = availableDirection;
                        minDistance = distance2;
                    }
                }
                if (GameObject.FindWithTag("Player1") != null)
                {
                    this.distance1 = (GameObject.FindWithTag("Player1").transform.position - newPosition).sqrMagnitude;

                    if (this.distance1 < minDistance)
                    {
                        direction = availableDirection;
                        minDistance = distance1;
                    }
                } 
                if (GameObject.FindWithTag("Player2") != null)
                {
                    this.distance2 = (GameObject.FindWithTag("Player2").transform.position - newPosition).sqrMagnitude;

                    if (this.distance2 < minDistance)
                    {
                        direction = availableDirection;
                        minDistance = distance2;
                    }
                }
            }
            this.dog.movement.SetDirection(direction);
        }
    }
}
