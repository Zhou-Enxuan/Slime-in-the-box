using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blocks : MonoBehaviour
{
    [SerializeField] private int width;

    [SerializeField] private int height;

    private Monster[,] allTiles;

    private Monster[,] viewTiles;

    [SerializeField] List<Block> blocks;

    [SerializeField] private Player player;

    [SerializeField] private SpriteRenderer playerSprite;

    private int offset;

    private int randomSize;

    private int randomMonsterId;

    private Animator anim;

    private Block HittingBlock;

    private int monsterSize;

    [SerializeField] private int minSize;

    [SerializeField] private int maxSize;

    private bool control;

    // Start is called before the first frame update


    private void Awake()
    {
        anim = GetComponent<Animator>();
        control = true;
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
        if(control)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveRight();
                control = false;

            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveLeft();
                control = false;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveUp();
                control = false;
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveDown();
                control = false;
            }
        }

    }

    private void Setup()
    {
        for (int i = 0, blockNum = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j, ++blockNum)
            {
                if (i != width / 2 || j != height / 2)
                {
                    monsterSize = CalculateMonsterSize();
                    randomMonsterId = Random.Range(1, 7);
                    allTiles[i, j] = new Monster(monsterSize, randomMonsterId);
                    blocks[blockNum].monster.data = allTiles[i, j];
                    blocks[blockNum].textCom.faceColor = new Color32(255, 255, 255, 0);
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
                    blocks[blockNum].monster.data = allTiles[i, j];
                    blocks[blockNum].monsterAnim.SetFloat("Blend", allTiles[i, j].size);
                    //blocks[blockNum].monster.UpdateSize();
                    blocks[blockNum].textCom.text = "7" + allTiles[i, j].getSize().ToString();
                    blocks[blockNum].textCom.faceColor = new Color32(255,255,255,255);
                    blocks[blockNum].SetAppear();
                    if ((blockNum == 7 || blockNum == 11 || blockNum == 13 || blockNum == 17 ))
                        UpdateBlockType(blockNum, allTiles[i, j].getSize());
                }
                else if(blockNum == 12)
                {
                    player.sprite.transform.localScale = new Vector3(1.8f / 6f * player.size, 1.8f / 6f * player.size, 1);
                    player.UpdateSize();
                    blocks[blockNum].blockType = BlockType.NORMAL;
                    blocks[blockNum].SetAppear();
                }
                else
                {
                    //blocks[blockNum].textCom.text = "";
                    blocks[blockNum].monster.data = allTiles[i, j];
                    blocks[blockNum].monsterAnim.SetFloat("Blend", allTiles[i, j].size);
                    //blocks[blockNum].monster.UpdateSize();
                    blocks[blockNum].textCom.text = "7" + allTiles[i, j].getSize().ToString();
                    blocks[blockNum].textCom.faceColor = new Color32(255, 255, 255, 0);
                    blocks[blockNum].blockType = BlockType.NORMAL;
                }

            }
        }

        //blocks[12].textCom.text = "";
        Debug.Log("update");
    }

    private void moveLeft()
    {
        HittingBlock = blocks[7];
        blocks[1].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[2].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[3].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[7].textCom.transform.parent.GetComponent<AttackNumber>().CalculateSize();
        int randomSize = CalculateMonsterSize();
        //补充第一行
        for (int col = 0; col < height; col++) {
            int colLength = width;

            // shift like normal
            for (int row = colLength - 1; row > 0; row--) {
                allTiles[row, col] = allTiles[row - 1, col];
            }
        }

        if((player.size == 1 || player.size == 6) && player.size == allTiles[width / 2, height / 2].getSize())
        {
            player.size = 3;
        }
        else if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }
        randomSize = CalculateMonsterSize();
        randomMonsterId = Random.Range(1, 7);
        allTiles[width / 2 + 1, height / 2] = new Monster(randomSize, randomMonsterId);

        for (int col = 0; col < height; col++)
        {
            int colLength = width;
            //添加新的怪物
            randomSize = CalculateMonsterSize();
            randomMonsterId = Random.Range(1, 7);
            allTiles[0, col] = new Monster(randomSize, randomMonsterId);
        }
        UpdateViewTiles();
        player.anim.SetTrigger("Horizontal");
        playerSprite.flipX = true;
        anim.SetTrigger("Left");
        //updateScreen();
        IsGameOver();
        if (!GameManager.instance.GameOver)
            GameManager.instance.ScoreUp();

    }

    private void moveRight()
    {
        HittingBlock = blocks[17];
        blocks[21].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[22].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[23].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[17].textCom.transform.parent.GetComponent<AttackNumber>().CalculateSize();
        //补充最后一行
        for (int col = 0; col < height; col++) {
            int colLength = width;

            // shift like normal
            for (int row = 0; row < colLength - 1; row++) {
                allTiles[row, col] = allTiles[row + 1, col];
            }

            //添加新的怪物到最后一行
        }
        
        if ((player.size == 1 || player.size == 6) && player.size == allTiles[width / 2, height / 2].getSize())
        {
            player.size = 3;
        }
        else if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }

        randomSize = CalculateMonsterSize();
        randomMonsterId = Random.Range(1, 7);
        allTiles[width / 2 - 1, height / 2] = new Monster(randomSize, randomMonsterId);

        for (int col = 0; col < height; col++)
        {
            int colLength = width;
            randomSize = CalculateMonsterSize();
            randomMonsterId = Random.Range(1, 7);
            allTiles[colLength - 1, col] = new Monster(randomSize, randomMonsterId);
        }
        UpdateViewTiles();
        player.anim.SetTrigger("Horizontal");
        playerSprite.flipX = false;
        anim.SetTrigger("Right");
        //updateScreen();
        //Score Up 
        IsGameOver();
        if (!GameManager.instance.GameOver)
            GameManager.instance.ScoreUp();

    }

    private void moveUp()
    {
        HittingBlock = blocks[11];
        blocks[5].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[10].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[15].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[11].textCom.transform.parent.GetComponent<AttackNumber>().CalculateSize();
        //补充第一列
        for (int row = 0; row < width; row++) {
            int rowLength = height;

            //复制先前的
            for (int col = rowLength - 1; col > 0; col--) {
                allTiles[row, col] = allTiles[row, col - 1];
            }
        }

        if ((player.size == 1 || player.size == 6) && player.size == allTiles[width / 2, height / 2].getSize())
        {
            player.size = 3;
        }
        else if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }

        randomSize = CalculateMonsterSize();
        randomMonsterId = Random.Range(1, 7);
        allTiles[width / 2, height / 2 + 1] = new Monster(randomSize, randomMonsterId);

        for (int row = 0; row < width; row++)
        {
            int rowLength = height;

            //添加新的怪物
            randomSize = CalculateMonsterSize();
            randomMonsterId = Random.Range(1, 7);
            allTiles[row, 0] = new Monster(randomSize, randomMonsterId);
        }
        UpdateViewTiles();
        player.anim.SetTrigger("Up");
        anim.SetTrigger("Up");
        //updateScreen();

        //Score Up 
        IsGameOver();
        if (!GameManager.instance.GameOver)
            GameManager.instance.ScoreUp();
    }

    private void moveDown()
    {
        HittingBlock = blocks[13];
        blocks[9].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[14].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[19].textCom.faceColor = new Color32(255, 255, 255, 255);
        blocks[13].textCom.transform.parent.GetComponent<AttackNumber>().CalculateSize();
        //补充最后一列
        for (int row = 0; row < width; row++) {
            int rowLength = height;

            //复制先前的
            for (int col = 0; col < rowLength - 1; col++) {
                allTiles[row, col] = allTiles[row, col + 1];
            }
        }

        if ((player.size == 1 || player.size == 6) && player.size == allTiles[width / 2, height / 2].getSize())
        {
            player.size = 3;
        }
        else if (player.size >= allTiles[width / 2, height / 2].getSize())
        {
            player.size = player.size - (allTiles[width / 2, height / 2].getSize() - player.size);
        }
        else
        {
            player.size = player.size + (player.size - allTiles[width / 2, height / 2].getSize());
        }

        randomSize = CalculateMonsterSize();
        randomMonsterId = Random.Range(1, 7);
        allTiles[width / 2, height / 2 - 1] = new Monster(randomSize, randomMonsterId);

        for (int row = 0; row < width; row++)
        {
            int rowLength = height;

            //添加新的怪物
            randomSize = CalculateMonsterSize();
            randomMonsterId = Random.Range(1, 7);
            allTiles[row, rowLength - 1] = new Monster(randomSize, randomMonsterId);
        }

        UpdateViewTiles();
        player.anim.SetTrigger("Down");
        anim.SetTrigger("Down");
        //updateScreen();

        //Score Up 
        IsGameOver();
        if (!GameManager.instance.GameOver)
            GameManager.instance.ScoreUp();
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
                if (Random.value <= 0.6f)
                    monsterSize = 1;
                else
                    monsterSize = Random.Range(2, 7);
                break;
            case 2:
                if (Random.value <= 0.1f)
                    monsterSize = 3;
                else if (Random.value <= 0.15f)
                    monsterSize = monsterSize = Random.Range(4, 7);
                else
                    monsterSize = monsterSize = Random.Range(1, 2);
                break;
            case 3:
                if (Random.value <= 0.05f)
                    monsterSize = 6;
                else if (Random.value <= 0.15f)
                    monsterSize = 5;
                else if (Random.value <= 0.35f)
                    monsterSize = 1;
                else if (Random.value <= 0.55f)
                    monsterSize = 4;
                else
                    monsterSize = monsterSize = Random.Range(2, 4);
                break;
            case 4:
                if (Random.value <= 0.05f)
                    monsterSize = 1;
                else if (Random.value <= 0.15f)
                    monsterSize = 2;
                else if (Random.value <= 0.35f)
                    monsterSize = 3;
                else if (Random.value <= 0.55f)
                    monsterSize = 6;
                else
                    monsterSize = monsterSize = Random.Range(4, 6);
                break;
            case 5:
                if (Random.value <= 0.1f)
                    monsterSize = 4;
                else if (Random.value <= 0.15)
                    monsterSize = Random.Range(1, 4);
                else
                    monsterSize = Random.Range(5, 7);

                break;
            case 6:
                if (Random.value <= 0.6f)
                    monsterSize = 6;
                else
                    monsterSize = Random.Range(1, 6);
                break;
        }
        return monsterSize;
    }

    public void UnlockControl()
    {
        control = true;
    }

    public void LockControl()
    {
        control = false;
    }

    private void IsGameOver()
    {
        if(player.size > 6 || player.size < 1)
        {
            GameManager.instance.GameOver = true;
            player.textMesh.gameObject.SetActive(false);
        }
    }

    private void RunAttackAnim()
    {
        HittingBlock.textAnim.SetTrigger("Attack");
    }
}
