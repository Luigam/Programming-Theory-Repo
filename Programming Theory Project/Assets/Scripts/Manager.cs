using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Manager : MonoBehaviour
{
    // ENCAPSULATION
    public static Manager Instance { get; private set; }

    public string username;

    AudioSource m_MyAudioSource;

    private void Awake()
    {
        m_MyAudioSource = GetComponent<AudioSource>();

        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //LoadHighScoreNameAndPoints();
        //SaveHighScoreNameAndPoints();

        //bestScoreText.text = $"Best Score : {oldHighScoreUsername}: {oldHighScorePoints}";
    }

    public void StopMusic()
    {
        m_MyAudioSource.Stop();

    }

    
}
