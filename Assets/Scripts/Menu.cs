using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Button start;

    private void Awake()
    {
        start = transform.GetChild(5).GetChild(0).GetComponent<Button>();
       
        start.onClick.AddListener(PlayGame);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");

    }

    public void CreditPage()
    {
        SceneManager.LoadScene("CreditPage");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
