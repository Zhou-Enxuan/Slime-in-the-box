using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    private Sprite sprite;

    private int size;

    public Monster(int _size)
    {
        size = _size;
    }

    ~Monster()
    {
        Debug.Log("Monster finalizer is called.");
    }

    public int getSize()
    {
        return size;
    }
}
