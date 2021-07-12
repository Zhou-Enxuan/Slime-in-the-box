using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehaviour : MonoBehaviour
{
    public Monster data;

    public int DiffValue; //player和monster的差值

    public GameObject sprite;

    private float spriteSize;

    private int fontValue; //加/减的数值
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void UpdateSize()
    //{
    //    switch (data.id)
    //    {
    //        case 1:
    //            spriteSize = 1.33f / 6f;
    //            spriteSize *= data.size;
    //            sprite.transform.localScale = new Vector3(spriteSize, spriteSize, 1);
    //            break;
    //        case 2:
    //            spriteSize = 1.5f / 6f;
    //            spriteSize *= data.size;
    //            sprite.transform.localScale = new Vector3(spriteSize, spriteSize, 1);
    //            break;
    //        case 3:
    //            spriteSize = 1.3f / 6f;
    //            spriteSize *= data.size;
    //            sprite.transform.localScale = new Vector3(spriteSize, spriteSize, 1);
    //            break;
    //        case 4:
    //            spriteSize = 1.2f / 6f;
    //            spriteSize *= data.size;
    //            sprite.transform.localScale = new Vector3(spriteSize, spriteSize, 1);
    //            break;
    //        case 5:
    //            spriteSize = 1.1f / 6f;
    //            spriteSize *= data.size;
    //            sprite.transform.localScale = new Vector3(spriteSize, spriteSize, 1);
    //            break;
    //        case 6:
    //            spriteSize = 1f / 6f;
    //            spriteSize *= data.size;
    //            sprite.transform.localScale = new Vector3(spriteSize, spriteSize, 1);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
