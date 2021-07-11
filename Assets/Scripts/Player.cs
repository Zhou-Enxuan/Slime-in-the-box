using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int size;

    public Animator anim;

    [SerializeField] private TextMeshProUGUI textMesh;

    void Update()
    {
        textMesh.text = size.ToString();
    }

    public void ResetSize()
    {
        size = 3;
    }
}
