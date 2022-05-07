using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

    public string username;

    private int m_exploredPercentage;
    public int exploredPercentage
    {
        get { return m_exploredPercentage; } // getter returns backing field
        set {
                if (value < 0)
                {

                    Debug.LogError("You can't set a negative explored percentage!");
                }
                else
                {
                    m_exploredPercentage = value; // original setter now in if/else statement
                }
            } // setter uses backing field
    }

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

    public Text eventText10;
    public Text eventText9;
    public Text eventText8;
    public Text eventText7;
    public Text eventText6;
    public Text eventText5;
    public Text eventText4;
    public Text eventText3;
    public Text eventText2;
    public Text eventText1;

    public RectTransform gameOverPanel;
    public Text gameOverText;
    public Button restartButton;


    Apple appleScript;
    Meat meatScript;

    Helmet helmetScript;
    Coat coatScript;
    Sword swordScript;

    Skeleton skeletonScript;
    Bandit banditScript;

    // Start is called before the first frame update
    void Start()
    {

        StartNew();

        appleScript = GetComponent<Apple>();
        meatScript = GetComponent<Meat>();

        skeletonScript = GetComponent<Skeleton>();
        banditScript = GetComponent<Bandit>();

        helmetScript = GetComponent<Helmet>();
        coatScript = GetComponent<Coat>();
        swordScript = GetComponent<Sword>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ABSTRACTION
    public void StartNew()
    {
        m_exploredPercentage = 0;

        eventText10.text = "";
        eventText9.text = "";
        eventText8.text = "";
        eventText7.text = "";
        eventText6.text = "";
        eventText5.text = "";
        eventText4.text = "";
        eventText3.text = "";
        eventText2.text = "";
        eventText1.text = "";
    }

    public void Explore()
    {
        m_exploredPercentage += 1;
        if (m_exploredPercentage <= 300)
        {
            if (m_exploredPercentage == 30)
            {
                UpdateLog("> You have explored");
                UpdateLog("> 10% of the forest");
            }
            else if (m_exploredPercentage == 75)
            {
                UpdateLog("> You have explored");
                UpdateLog("> 25% of the forest");
            }
            else if (m_exploredPercentage == 270)
            {
                UpdateLog("> You have explored");
                UpdateLog("> 90% of the forest");
            }

            if (m_exploredPercentage == 300)
            {
                UpdateLog("> You have explored");
                UpdateLog("> 100% of the forest!");
                UpdateLog("> Finally you found the exit");
                UpdateLog("> Congratulations!");
                UpdateLog(">  And thank you for playing");
            }
            else
            {
                UpdateLog(RandomEvent());
            }
        }
        else if (m_exploredPercentage == 310)
        {
            UpdateLog("> You really want to keep playing huh?");
            UpdateLog("> Sorry");
            UpdateLog("> That is the end of the game for now :)");
        }
    }

    string RandomEvent()
    {
        int randomNumber;
        string randomEvent = "empty";
        
        randomNumber = Random.Range(1, 101);
        Debug.Log(randomNumber);

        if (randomNumber <= 75)
        {
            randomEvent = "> You are walking...";
            Debug.Log(randomEvent);
        }
        else if (randomNumber <= 85)
        {
            if (Random.Range(1, 3) == 1)
            {
                randomEvent = skeletonScript.EnemyFound();
                Player.Instance.Battle("Skeleton");
            }
            else
            {
                randomEvent = banditScript.EnemyFound();
                Player.Instance.Battle("Bandit");
            }
            Debug.Log(randomEvent);
        }
        else if (randomNumber <= 95)
        {
            if (Random.Range(1, 3) == 1)
            {
                randomEvent = appleScript.ConsumableFound();
            }
            else
            {
                randomEvent = meatScript.ConsumableFound();
            }
            
        }
        else if (randomNumber <= 100)
        {
            int randomAccessory = Random.Range(1, 4);

            if (randomAccessory == 1)
            {
                randomEvent = helmetScript.AccessoryFound();
            }
            else if (randomAccessory == 2)
            {
                randomEvent = coatScript.AccessoryFound();
            }
            else
            {
                randomEvent = swordScript.AccessoryFound();
            }
            Debug.Log(randomEvent);
        }
        else
        {
            Debug.Log("error");
        }
        Debug.Log(randomEvent);
        return randomEvent;
        
    }

    public void UpdateLog(string newEvent)
    {
        eventText10.text = eventText9.text;
        eventText9.text = eventText8.text;
        eventText8.text = eventText7.text;
        eventText7.text = eventText6.text;
        eventText6.text = eventText5.text;
        eventText5.text = eventText4.text;
        eventText4.text = eventText3.text;
        eventText3.text = eventText2.text;
        eventText2.text = eventText1.text;
        eventText1.text = newEvent;
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        StartNew();
        Player.Instance.StartNew();
    }

    public void Restart()
    {
        gameOverPanel.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        
    }

}
