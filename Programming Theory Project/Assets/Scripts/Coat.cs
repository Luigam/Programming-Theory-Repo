using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE

public class Coat : Accessory
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
    public override string AccessoryFound()
    {
        string message;
        message = "> You found a coat";
   
        Player.Instance.EquipCoat();

        return message;
    }

}
