using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BlockType { NORMAL, SMALLER, LARGER, ITEM };
public class Block : MonoBehaviour
{
    public Text textCom;

    public Sprite smaller, larger, normal, item;

    public BlockType blockType;

    private bool isAppear;

    Image img;
    private void Awake()
    {
        img = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        isAppear = false;
    }
    private void Update()
    {
        UpdateColor();
        if (!isAppear)
            img.enabled = false;

    }

    void UpdateColor()
    {
        switch (blockType)
        {
            case BlockType.SMALLER:
                img.sprite = smaller;
                break;
            case BlockType.LARGER:
                img.sprite = larger;
                break;
            case BlockType.ITEM:
                img.sprite = item;
                break;
        }
    }

    public void SetAppear()
    {
        isAppear = true;
    }
}
