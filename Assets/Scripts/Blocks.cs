using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private int width;

    [SerializeField] private int height;

    private Block[,] allTiles;

    private Block[,] viewTiles;

    private int offset;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new Block[width, height];

        viewTiles = new Block[3, 3];

        offset = (width - 3) / 2;

        Setup();

        UpdateViewTiles();
    }

    void Update()
    {
        
    }

    private void Setup()
    {
        for(int i = 0; i < width; ++i)
        {
            for(int j = 0; j < height; ++j)
            {
                if(i != width/2 && j != height/2)
                {
                    int randomSize = Random.Range(1, 7);
                    allTiles[i, j].monster = new Monster(randomSize);
                }
               
            }
        }
    }

    private void UpdateViewTiles()
    {
        for(int i = offset -1, _i = 0; i < offset + 3; ++i, ++_i)
        {
            for (int j = offset - 1, _j = 0; j < offset + 3; ++j, ++_j)
            {
                viewTiles[_i, _j] = allTiles[i, j];
            }
        }
    }

    private void moveUp()
    {

    }

    private void moveDown()
    {

    }

    private void moveLeft()
    {

    }

    private void moveRight()
    {

    }
}
