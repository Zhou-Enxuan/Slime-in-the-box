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

    [SerializeField] private Player player;

    private int offset;

    private int randomSize;

    private Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        allTiles = new Monster[width, height];

        viewTiles = new Monster[3, 3];

        offset = (width - 3) / 2;

        Setup();
        printArray();

        UpdateViewTiles();

        updateScreen();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRight();
            anim.SetTrigger("Right");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeft();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUp();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown();
        }
    }

    private void Setup()
    {
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                if (i != width / 2 || j != height / 2)
                {
                    randomSize = Random.Range(1, 7);
                    allTiles[i, j] = new Monster(randomSize);
                }

            }
        }
    }

    private void UpdateViewTiles()
    {
        for (int i = offset, _i = 0; _i < 3; ++i, ++_i)
        {
            for (int j = offset, _j = 0; _j < 3; ++j, ++_j)
            {
                if (i != width / 2 || j != height / 2)
                {
                    viewTiles[_i, _j] = allTiles[i, j];
                }
                else
                {
                    allTiles[i, j] = null;
                    viewTiles[_i, _j] = null;
                }
            }
        }
    }

    private void updateScreen()
    {
        for (int i = 0, blockNum = 0; i < 5; ++i)
        {
            for (int j = 0; j < 5; ++j, ++blockNum)
            {
                if ((blockNum > 5 && blockNum < 9) || (blockNum == 11 || blockNum == 13) || (blockNum > 15 && blockNum < 19))
                {
                    blocks[blockNum].textCom.text = allTiles[i, j].getSize().ToString();
                }
                else
                {
                    blocks[blockNum].textCom.text = "";
                }

            }
        }

        blocks[12].textCom.text = player.size.ToString();
    }

    private void moveLeft()
    {
        int randomSize = Random.Range(1, 7);
        //补充第一行
        for (int col = 0; col < height; col++) {
            int colLength = width;

            // shift like normal
            for (int row = colLength - 1; row > 0; row--) {
                allTiles[row, col] = allTiles[row - 1, col];
            }

            //添加新的怪物
            randomSize = Random.Range(1, 7);
            allTiles[0, col] = new Monster(randomSize);
        }
        randomSize = Random.Range(1, 7);
        allTiles[width / 2 + 1, height / 2] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size += allTiles[width / 2, height / 2].getSize();
        }
        else
        {
            player.size -= (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        UpdateViewTiles();
        //updateScreen();
    }

    private void moveRight()
    {
        //补充最后一行
        for (int col = 0; col < height; col++) {
            int colLength = width;

            // shift like normal
            for (int row = 0; row < colLength - 1; row++) {
                allTiles[row, col] = allTiles[row + 1, col];
            }

            //添加新的怪物到最后一行
            randomSize = Random.Range(1, 7);
            allTiles[colLength - 1, col] = new Monster(randomSize);
        }
        randomSize = Random.Range(1, 7);
        allTiles[width / 2 - 1, height / 2] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size += allTiles[width / 2, height / 2].getSize();
        }
        else
        {
            player.size -= (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        UpdateViewTiles();
        //updateScreen();


    }

    private void moveUp()
    {
        //补充第一列
        for (int row = 0; row < width; row++) {
            int rowLength = height;

            //复制先前的
            for (int col = rowLength - 1; col > 0; col--) {
                allTiles[row, col] = allTiles[row, col - 1];
            }

            //添加新的怪物
            randomSize = Random.Range(1, 7);
            allTiles[row, 0] = new Monster(randomSize);
        }
        randomSize = Random.Range(1, 7);
        allTiles[width / 2, height / 2 + 1] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size += allTiles[width / 2, height / 2].getSize();
        }
        else
        {
            player.size -= (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        UpdateViewTiles();
        //updateScreen();
    }

    private void moveDown()
    {
        //补充最后一列
        for (int row = 0; row < width; row++) {
            int rowLength = height;

            //复制先前的
            for (int col = 0; col < rowLength - 1; col++) {
                allTiles[row, col] = allTiles[row, col + 1];
            }

            //添加新的怪物
            randomSize = Random.Range(1, 7);
            allTiles[row, rowLength - 1] = new Monster(randomSize);
        }
        randomSize = Random.Range(1, 7);
        allTiles[width / 2, height / 2 - 1] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size += allTiles[width / 2, height / 2].getSize();
        }
        else
        {
            player.size -= (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        UpdateViewTiles();
        //updateScreen();
    }

    private void printArray()
    {
        string result = "";
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                if (i != width / 2 || j != height / 2)
                {
                    result += allTiles[j, i].getSize().ToString();
                    result += ", ";
                }
                else
                {
                    result += -1;
                    result += ", ";
                }

            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
