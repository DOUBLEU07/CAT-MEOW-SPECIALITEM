using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class DogBehavior : NetworkBehaviour
{
    public Dog dog { get; private set; }

    private void Awake()
    {
        this.dog = GetComponent<Dog>();
    }
}
