using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void IncreaseHealth()
    {
        Player.Instance.health += 80;
    }

    public virtual void IncreaseStrength()
    {
        Player.Instance.strength += 10;
    }

    public virtual string AccessoryFound()
    {
        string message;
        message = "> You found an accessory";

        return message;
    }
}
