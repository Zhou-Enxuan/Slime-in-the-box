using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private int width;

    [SerializeField] private int height;

    private Monster[,] allTiles;

    private Monster[,] viewTiles;

    [SerializeField] List<Block> blocks;

    private int offset;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new Monster[width, height];

        viewTiles = new Monster[3, 3];

        offset = (width - 3) / 2;

        Setup();

        UpdateViewTiles();

        updateScreen();
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
                if(i != width/2 || j != height/2)
                {
                    int randomSize = Random.Range(1, 7);
                    allTiles[i, j] = new Monster(randomSize);
                }
               
            }
        }
    }

    private void UpdateViewTiles()
    {
        for(int i = offset, _i = 0; _i < 3; ++i, ++_i)
        {
            for (int j = offset, _j = 0; _j < 3; ++j, ++_j)
            {
                if (i != width / 2 || j != height / 2)
                {
                    viewTiles[_i, _j] = allTiles[i, j];
                }
            }
        }
    }

    private void updateScreen()
    {
        for (int i = 0, blockNum = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j, ++blockNum)
            {
                if (i != 1 || j != 1)
                {
                    blocks[blockNum].textCom.text = viewTiles[i, j].getSize().ToString();
                }
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
