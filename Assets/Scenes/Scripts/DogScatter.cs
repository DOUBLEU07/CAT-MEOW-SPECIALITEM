using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScatter : DogBehavior
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.dog.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.dog.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
