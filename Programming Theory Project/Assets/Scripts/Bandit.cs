using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE

public class Bandit : Enemy
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
        message = "> A Bandit is trying to attack you!";

        return message;
    }

    public override string DealDamage()
    {
        string message;

        Player.Instance.health -= 5;
        message = "> The bandit hurt you!";

        return message;
    }
}
