using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public bool GameOver;

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
        IsGameOver();
    }

    public void sceneSwitch()
    {

    }

    public void ScoreUp()
    {
        score += 1;
    }

    private void IsGameOver()
    {
        if (GameOver)
        {
            Debug.Log("Game Over");
            Instantiate<>
        }
    }

}
