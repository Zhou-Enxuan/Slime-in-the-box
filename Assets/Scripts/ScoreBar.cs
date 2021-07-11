using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    Text scoreBar;

    private void Awake()
    {
        scoreBar = transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        scoreBar.text = GameManager.instance.score.ToString("0000");
    }
}
