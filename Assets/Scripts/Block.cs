using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BlockType { NORMAL, SMALLER, LARGER, ITEM };
public class Block : MonoBehaviour
{
    public TextMeshProUGUI textCom;

    public Sprite smaller, larger, normal, item;

    public BlockType blockType;

    private bool isAppear;

    private void Awake()
    {
        isAppear = false;
    }
    private void Update()
    {
        UpdateColor();
        //if (!isAppear)
        //    img.enabled = false;

    }

    void UpdateColor()
    {
        switch (blockType)
        {
            case BlockType.SMALLER:
                GetComponent<SpriteRenderer>().sprite = smaller;
                break;
            case BlockType.LARGER:
                GetComponent<SpriteRenderer>().sprite = larger;
                break;
            case BlockType.ITEM:
                GetComponent<SpriteRenderer>().sprite = item;
                break;
        }
    }

    public void SetAppear()
    {
        isAppear = true;
    }
}
