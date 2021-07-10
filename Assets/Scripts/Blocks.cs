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
        //补充第一行
        for (int col = 0; col < allTiles.length; col++) {
            int colLength = allTiles[col].length;

            // shift like normal
            for (int row = colLength; row > 1; row--) {
                allTiles[row][col] = allTiles[row - 1][col];
            }

            //添加新的怪物
            int randomSize = Random.Range(1, 7);
            allTiles[0][col] = new Monster(randomSize);
        }
    }

    private void moveDown()
    {
        //补充最后一行
        for (int col = 0; col < allTiles.length; col++) {
            int colLength = allTiles[col].length;

            // shift like normal
            for (int row = 0; row < colLength - 1; row++) {
                allTiles[row][col] = allTiles[row + 1][col];
            }

            //添加新的怪物到最后一行
            int randomSize = Random.Range(1, 7);
            allTiles[colLength][col] = new Monster(randomSize);
        }
    }

    private void moveLeft()
    {
        //补充第一列
        for (int row = 0; row < allTiles.length; row++) {
            int rowLength = allTiles[row].length;

            //复制先前的
            for (int col = rowLength; col > 1; col--) {
                allTiles[row][col] = allTiles[row][col - 1];
            }

            //添加新的怪物
            int randomSize = Random.Range(1, 7);
            allTiles[row][0] = new Monster(randomSize);
        }
    }

    private void moveRight()
    {
        //补充最后一列
        for (int row = 0; row < allTiles.length; row++) {
            int rowLength = allTiles[row].length;

            //复制先前的
            for (int col = 0; col < rowLength - 1; col++) {
                allTiles[row][col] = allTiles[row][col + 1];
            }

            //添加新的怪物
            int randomSize = Random.Range(1, 7);
            allTiles[row][rowLength] = new Monster(randomSize);
        }
    }
}
