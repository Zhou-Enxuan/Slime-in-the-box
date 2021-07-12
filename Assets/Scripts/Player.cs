using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int size;

    public Animator anim;

    public TextMeshProUGUI textMesh;

    public GameObject sprite;

    void Start()
    {
        size = 3;  
    }

    void Update()
    {
        textMesh.text = size.ToString();
    }

    public void ResetSize()
    {
        size = 3;
    }

    private void updateSizeAnim()
    {
        textMesh.text = size.ToString();
    }
}
