using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditControl : MonoBehaviour
{
    public GameObject credit;
    private  float speed;
    void Start()
    {
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if(credit.transform.position.y < 720)
            credit.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        else
            SceneManager.LoadScene("Menu");

        if(Input.GetMouseButtonDown(0))
            speed = 500;

        if(Input.GetMouseButtonUp(0))
            speed = 50;
    }
}
