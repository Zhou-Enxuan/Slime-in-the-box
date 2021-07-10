using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    private Sprite sprite;

    private int size;

    private Player player;

    public Monster(int _size)
    {
        size = _size;
    }

    ~Monster()
    {
        //Debug.Log("Monster finalizer is called.");
    }

    public int getSize()
    {
        return size;
    }

    public void CalculateMonsterSize()
    {
        //当玩家是1的时候，八个格子70 % 概率出现1

        //当玩家是2的时候，八个格子70 % 概率出现1，2，3

        //当玩家是3的时候，八个格子90 % 概率出现1，2，3，4，5

        //当玩家是4的时候，八个格子90 % 概率出现2，3，4，5，6

        //当玩家是5的时候，八个格子80 % 概率出现4，5，6

        //当玩家是6的时候，八个格子70 % 概率出现6

        switch (player.size)
        {
            case 1:
                if (Random.value <= 0.7f)
                    size = 1;
                else
                    size = Random.Range(2, 6);
                break;
            case 2:
                if (Random.value <= 0.23f)
                    size = 1;
                else if (Random.value <= 0.46f)
                    size = 2;
                else if (Random.value <= 0.7f)
                    size = 3;
                else
                    size = Random.Range(4, 6);
                break;
            case 3:
                if (Random.value <= 0.18f)
                    size = 1;
                else if (Random.value <= 0.36f)
                    size = 2;
                else if (Random.value <= 0.54f)
                    size = 3;
                else if (Random.value <= 0.72f)
                    size = 4;
                else if (Random.value <= 0.9f)
                    size = 5;
                else
                    size = 6;
                break;
            case 4:
                if (Random.value <= 0.18f)
                    size = 6;
                else if (Random.value <= 0.36f)
                    size = 2;
                else if (Random.value <= 0.54f)
                    size = 3;
                else if (Random.value <= 0.72f)
                    size = 4;
                else if (Random.value <= 0.9f)
                    size = 5;
                else
                    size = 1;
                break;
            case 5:
                if (Random.value <= 0.23f)
                    size = 4;
                else if (Random.value <= 0.46f)
                    size = 5;
                else if (Random.value <= 0.7f)
                    size = 6;
                break;
            case 6:
                if (Random.value <= 0.7f)
                    size = Random.Range(1, 3);
                break;
        }
    }

    
}
