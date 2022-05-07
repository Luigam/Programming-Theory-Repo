using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int healthPoints = 70;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual string EnemyFound()
    {
        string message;
        message = "> An enemy is trying to attack you!";

        return message;
    }

    public virtual string DealDamage()
    {
        Player.Instance.health -= 10;

        string message;
        message = "> The enemy hurt you, you lost some health!";

        return message;
    }
}
