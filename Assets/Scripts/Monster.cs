using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public int size { get; private set;}

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

    

    
}
