using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button start;
    public Button Credit;
    public Button Setting;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start.gameObject.SetActive(true);
            Credit.gameObject.SetActive(true);
            Setting.gameObject.SetActive(true);
            anim.SetTrigger("Start");
        }
    }

    public void PlayGame()
    {
        anim.SetTrigger("Start2");
        

    }

    public void CreditPage()
    {
        anim.SetTrigger("Credit");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void switchScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ButtonSoundEF() {
        SoundManager.playSEOne("button");
    }




}
