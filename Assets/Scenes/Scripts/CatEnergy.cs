using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnergy : NormalFood
{
    public int duration = 8;
    public bool energyEaten = false;

    protected override void Eat()
    {
        FindObjectOfType<GameManager>().CatEnergyEaten();
        FindObjectOfType<GameManager>().NormalFoodEaten(this);
        SoundManager.PlaySound("CatEnergyEaten");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            Eat();
        }
    }
}
