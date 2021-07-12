using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public bool GameOver;

    public GameObject UI;

    public bool counter = false;

    public bool control = true;

    public bool paused = false;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start() {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if(counter == false)
            IsGameOver(); 
    }

    public void sceneSwitch()
    {
        SceneManager.LoadScene("Main");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ScoreUp()
    {
        score += 1;
    }

    private void IsGameOver()
    {
        if (GameOver)
        {
            //transform.GetComponent<Blocks>().LockControl();
            Debug.Log("Game Over");
            if (counter == false)
            {
                ScoreBar.instance.showBoard();
                counter = true;
            }
        }
    }

}
