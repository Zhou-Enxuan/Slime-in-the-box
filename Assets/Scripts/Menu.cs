using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button start;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
       
        start.onClick.AddListener(PlayGame);

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Start");
        }
    }

    public void PlayGame()
    {
        anim.SetTrigger("Start");
        

    }

    public void CreditPage()
    {
        SceneManager.LoadScene("CreditPage");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void switchScene(string name)
    {
        SceneManager.LoadScene(name);
    }





}
