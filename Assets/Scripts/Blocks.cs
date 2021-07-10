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

    private int monsterSize;

    [SerializeField] private int minSize;

    [SerializeField] private int maxSize;
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
                    monsterSize = CalculateMonsterSize();
                    allTiles[i, j] = new Monster(monsterSize);
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
                    blocks[blockNum].blockType = BlockType.NORMAL;
                    blocks[blockNum].SetAppear();
                    if ((blockNum == 7 || blockNum == 11 || blockNum == 13 || blockNum == 17 ))
                        UpdateBlockType(blockNum, allTiles[i, j].getSize());
                }
                else if(blockNum == 12)
                {
                    blocks[blockNum].blockType = BlockType.NORMAL;
                    blocks[blockNum].SetAppear();
                }
                else
                {
                    blocks[blockNum].textCom.text = "";
                    blocks[blockNum].blockType = BlockType.NORMAL;
                }

            }
        }

        blocks[12].textCom.text = player.size.ToString();
        Debug.Log("update");
    }

    private void moveLeft()
    {
        int randomSize = CalculateMonsterSize();
        //补充第一行
        for (int col = 0; col < height; col++) {
            int colLength = width;

            // shift like normal
            for (int row = colLength - 1; row > 0; row--) {
                allTiles[row, col] = allTiles[row - 1, col];
            }

            //添加新的怪物
            randomSize = CalculateMonsterSize();
            allTiles[0, col] = new Monster(randomSize);
        }
        randomSize = CalculateMonsterSize();
        allTiles[width / 2 + 1, height / 2] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }
        UpdateViewTiles();
        anim.SetTrigger("Left");
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
            randomSize = CalculateMonsterSize();
            allTiles[colLength - 1, col] = new Monster(randomSize);
        }
        randomSize = CalculateMonsterSize();
        allTiles[width / 2 - 1, height / 2] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }
        UpdateViewTiles();
        anim.SetTrigger("Right");
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
            randomSize = CalculateMonsterSize();
            allTiles[row, 0] = new Monster(randomSize);
        }
        randomSize = CalculateMonsterSize();
        allTiles[width / 2, height / 2 + 1] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }
        UpdateViewTiles();
        anim.SetTrigger("Up");
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
            randomSize = CalculateMonsterSize();
            allTiles[row, rowLength - 1] = new Monster(randomSize);
        }
        randomSize = CalculateMonsterSize();
        allTiles[width / 2, height / 2 - 1] = new Monster(randomSize);

        if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }
        UpdateViewTiles();
        anim.SetTrigger("Down");
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

    private void UpdateBlockType(int number, int size)
    {
        if (viewTiles != null)
        {
            if (size <= player.size)
                blocks[number].blockType = BlockType.SMALLER;
            else if (size > player.size)
                blocks[number].blockType = BlockType.LARGER;
            blocks[number].SetAppear();
        }
    }

    public int CalculateMonsterSize()
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
                    monsterSize = 1;
                else
                    monsterSize = Random.Range(2, 7);
                break;
            case 2:
                if (Random.value <= 0.23f)
                    monsterSize = 1;
                else if (Random.value <= 0.46f)
                    monsterSize = 2;
                else if (Random.value <= 0.7f)
                    monsterSize = 3;
                else
                    monsterSize = Random.Range(4, 7);
                break;
            case 3:
                if (Random.value <= 0.18f)
                    monsterSize = 1;
                else if (Random.value <= 0.36f)
                    monsterSize = 2;
                else if (Random.value <= 0.54f)
                    monsterSize = 3;
                else if (Random.value <= 0.72f)
                    monsterSize = 4;
                else if (Random.value <= 0.9f)
                    monsterSize = 5;
                else
                    monsterSize = 6;
                break;
            case 4:
                if (Random.value <= 0.18f)
                    monsterSize = 6;
                else if (Random.value <= 0.36f)
                    monsterSize = 2;
                else if (Random.value <= 0.54f)
                    monsterSize = 3;
                else if (Random.value <= 0.72f)
                    monsterSize = 4;
                else if (Random.value <= 0.9f)
                    monsterSize = 5;
                else
                    monsterSize = 1;
                break;
            case 5:
                if (Random.value <= 0.23f)
                    monsterSize = 4;
                else if (Random.value <= 0.46f)
                    monsterSize = 5;
                else if (Random.value <= 0.7f)
                    monsterSize = 6;
                else
                    monsterSize = Random.Range(1, 4);
                break;
            case 6:
                if (Random.value <= 0.7f)
                    monsterSize = Random.Range(1, 4);
                else
                    monsterSize = Random.Range(1, 6);
                break;
        }
        return monsterSize;
    }
}
