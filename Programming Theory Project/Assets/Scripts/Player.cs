using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // ENCAPSULATION
    public static Player Instance { get; private set; }

    public int health;
    public int strength;
    public int apples;
    public int meats;
    public bool helmet;
    public bool coat;
    public bool sword;
    public int exploredPercentage;

    public Text playerNameText;
    public Text healthPointsText;
    public Text strenghtPointsText;

    public Text consumablesText;
    public Text applesText;
    public Text meatsText;

    public Text accessoriesText;
    public Text helmetText;
    public Text coatText;
    public Text swordText;

    public Text exploredPercentageText;

    public Button exploreButton;
    public Button eatAppleButton;
    public Button eatMeatButton;
    public Button attackButton;


    Apple appleScript;
    Meat meatScript;

    Skeleton skeletonScript;
    Bandit banditScript;

    public string currentEnemyType;
    public int currentEnemyHealth;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        StartNew();

        appleScript = GetComponent<Apple>();
        meatScript = GetComponent<Meat>();
        skeletonScript = GetComponent<Skeleton>();
        banditScript = GetComponent<Bandit>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // ABSTRACTION
    public void StartNew()
    {
        playerNameText.text = Manager.Instance.username;

        health = 100;
        strength = 6;
        apples = 0;
        meats = 0;
        helmet = false;
        coat = false;
        sword = false;
        exploredPercentage = 0;

        healthPointsText.text = "Health Points : 100";
        strenghtPointsText.text = "Strength Points : 6";

        applesText.text = "0 Apple";
        meatsText.text = "0 Meat";

        helmetText.text = "0 Helmet";
        coatText.text = "0 Coat";
        swordText.text = "0 Sword";
}

    public void EquipHelmet()
    {
        if (!helmet)
        {
            helmet = true;
            helmetText.text = "1 Helmet (+95 Health)";
            health += 95;
            Debug.Log(health);
            healthPointsText.text = "Health Points : " + health;
        }
    }

    public void EquipCoat()
    {
        if (!coat)
        {
            coat = true;
            coatText.text = "1 Coat (+76 Health)";
            health += 76;
            Debug.Log(health);
            healthPointsText.text = "Health Points : " + health;
        }
    }

    public void EquipSword()
    {
        if (!sword)
        {
            sword = true;
            swordText.text = "1 Sword (+9 Strength)";
            strength += 9;
            Debug.Log(strength);
            strenghtPointsText.text = "Strength Points : " + strength;
        }
    }

    public void StoreApple()
    {
        apples += 1;
        applesText.text = apples + " Apple";
        if (!eatAppleButton.gameObject.activeInHierarchy)
        {
            eatAppleButton.gameObject.SetActive(true);
        }
}

    public void StoreMeat()
    {
        meats += 1;
        meatsText.text = meats + " Meat";
        if (!eatMeatButton.gameObject.activeInHierarchy)
        {
            eatMeatButton.gameObject.SetActive(true);
        }
    }

    public void EatApple()
    {
        apples -= 1;
        applesText.text = apples + " Apple";
        if (apples == 0)
        {
            eatAppleButton.gameObject.SetActive(false);
        }
        appleScript.RestoreHealth();
        healthPointsText.text = "Health Points : " + health;
    }

    public void EatMeat()
    {
        meats -= 1;
        meatsText.text = meats + " Meat";
        if (meats == 0)
        {
            eatMeatButton.gameObject.SetActive(false);
        }
        meatScript.RestoreHealth();
        healthPointsText.text = "Health Points : " + health;
    }

    public void Battle(string enemyType)
    {
        currentEnemyType = enemyType;
        if (enemyType == "Skeleton")
        {
            currentEnemyHealth = skeletonScript.healthPoints;
        }
        else
        {
            currentEnemyHealth = banditScript.healthPoints;
        }
        
        exploreButton.gameObject.SetActive(false);
        attackButton.gameObject.SetActive(true);

    }

    public void Attack()
    {
        string message;
        currentEnemyHealth -= strength;

        if (currentEnemyHealth <= 0)
        {
            message = "> You defeated the " + currentEnemyType + "!";
            GameManager.Instance.UpdateLog(message);
            
            exploreButton.gameObject.SetActive(true);
            attackButton.gameObject.SetActive(false);

        }
        else
        {
            message = "> " + currentEnemyType + " lost " + strength + " health, " + currentEnemyHealth + " left";
            GameManager.Instance.UpdateLog(message);

            if (currentEnemyType == "Skeleton")
            {
                message = skeletonScript.DealDamage();
                GameManager.Instance.UpdateLog(message);
            }
            else
            {
                message = banditScript.DealDamage();
                GameManager.Instance.UpdateLog(message);
            }
        }
        
        

        healthPointsText.text = "Health Points : " + health;

        if (health <= 0)
        {
            GameManager.Instance.GameOver();

            exploreButton.gameObject.SetActive(true);
            attackButton.gameObject.SetActive(false);

            eatAppleButton.gameObject.SetActive(false);
            eatMeatButton.gameObject.SetActive(false);
        }
    }

    

}
