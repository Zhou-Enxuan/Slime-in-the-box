using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public bool GameOver;

    public GameObject GameOverWindow;

    public bool counter = false;

    void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
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
                Instantiate(GameOverWindow, this.transform.position, this.transform.rotation);
                counter = true;
            }
        }
    }

}
