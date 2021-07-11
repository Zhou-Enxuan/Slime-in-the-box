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
