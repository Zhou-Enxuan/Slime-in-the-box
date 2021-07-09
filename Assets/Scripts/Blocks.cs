using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private int width;

    [SerializeField] private int height;

    private Block[,] allTiles;

    private Block[,] viewTiles;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new Block[width, height];

        viewTiles = new Block[3, 3];

        Setup();

        UpdateViewTiles();
    }

    void Update()
    {
        
    }

    private void Setup()
    {
    }

    private void UpdateViewTiles()
    {
       
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
