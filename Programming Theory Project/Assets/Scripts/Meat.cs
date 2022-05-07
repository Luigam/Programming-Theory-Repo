using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE

public class Meat : Consumable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // POLYMORPHISM
    public override void RestoreHealth()
    {
        Player.Instance.health += 13;
    }

    public override string ConsumableFound()
    {
        string message;
        message = "> You found meat";
        Player.Instance.StoreMeat();

        return message;
    }
}
