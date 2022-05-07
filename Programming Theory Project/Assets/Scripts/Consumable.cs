using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void RestoreHealth()
    {
        Player.Instance.health += 5;
    }

    public virtual string ConsumableFound()
    {
        string message;
        message = "> You found a consumable";

        return message;
    }
}
