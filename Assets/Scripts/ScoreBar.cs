using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Text scoreBar;

    private void Update()
    {
        scoreBar.text = GameManager.instance.score.ToString("0000");
    }
}
