using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE

public class Skeleton : Enemy
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
    public override string EnemyFound()
    {
        string message;
        message = "> A Skeleton is trying to attack you!";

        return message;
    }

    public override string DealDamage()
    {
        string message;

        Player.Instance.health -= 3;
        message = "> The skeleton hurt you!";

        return message;
    }


}
