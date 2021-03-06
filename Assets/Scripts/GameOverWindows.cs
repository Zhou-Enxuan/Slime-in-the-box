using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindows : MonoBehaviour
{
    Text score;
    Button restart;
    public Blocks blocks;
    public Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        //blocks = GetComponent<Blocks>();
        //player = GetComponent<Player>();
        score = transform.GetChild(1).GetComponent<Text>();
        restart = transform.GetChild(2).GetComponent<Button>();

        restart.onClick.AddListener(RestartGame);
        score.text = "Your Score: " + GameManager.instance.score.ToString();
    }



    private void RestartGame()
    {
        //GameManager.instance.score = 0;
        //blocks.UnlockControl();
        //player.ResetSize();
        //GameManager.instance.GameOver = false;
        //GameManager.instance.counter = false;
        //Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);
        GameManager.instance.score = 0;
        GameManager.instance.GameOver = false;
        GameManager.instance.counter = false;
        SceneManager.LoadScene(2);
    }

}
