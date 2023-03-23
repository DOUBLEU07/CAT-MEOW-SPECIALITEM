using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogBehavior_SG : MonoBehaviour
{
    public Dog_SG dog { get; private set; }

    private void Awake()
    {
        this.dog = GetComponent<Dog_SG>();
    }
}
