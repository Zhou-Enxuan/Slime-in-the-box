using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBar : MonoBehaviour
{
    public static ScoreBar instance;

    public Text scoreBar;

    public GameObject Mask;

    public GameObject ScoreBoard;

    public GameObject QuitBoard;

    public Text Score;

    public GameObject hint;

    void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(instance);
            instance = this;

        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        scoreBar.text = GameManager.instance.score.ToString("0000");

        if(hint.activeSelf && Input.GetMouseButtonDown(0))
        {
            Mask.SetActive(false);
            hint.SetActive(false);
            GameManager.instance.control = true;
        }
    }

    public void showBoard()
    {
        Mask.SetActive(true);
        ScoreBoard.SetActive(true);
        Score.text = GameManager.instance.score.ToString();
    }

    public void showHint()
    {
        Mask.SetActive(true);
        hint.SetActive(true);
        GameManager.instance.control = false;
    }

    public void showQuitBoard()
    {
        Mask.SetActive(true);
        QuitBoard.SetActive(true);
        GameManager.instance.control = false;
    }

    public void YesToQuit()
    {
        GameManager.instance.score = 0;
        GameManager.instance.GameOver = false;
        GameManager.instance.counter = false;
        SceneManager.LoadScene(0);
    }

    public void NoToQuit()
    {
        Mask.SetActive(false);
        QuitBoard.SetActive(false);
        GameManager.instance.control = true;
    }

    public void RestartGame()
    {
        GameManager.instance.score = 0;
        GameManager.instance.GameOver = false;
        GameManager.instance.counter = false;
        SceneManager.LoadScene(2);
    }
}
