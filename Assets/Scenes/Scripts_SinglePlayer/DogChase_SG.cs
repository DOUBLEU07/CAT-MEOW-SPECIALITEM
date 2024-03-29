using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChase_SG : DogBehavior_SG
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (!gameManager.stopDog){
            if (node != null && this.enabled)
            {
                Vector2 direction = Vector2.zero;
                float minDistance = float.MaxValue;

                foreach (Vector2 availableDirection in node.availableDirections)
                {
                    Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                    float distance = (this.dog.target.position - newPosition).sqrMagnitude;

                    if (distance < minDistance)
                    {
                        direction = availableDirection;
                        minDistance = distance;
                    }
                }
                this.dog.movement.SetDirection(direction);
        }
        }
    }
}
