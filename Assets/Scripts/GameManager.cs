using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GridGenerator gridGenerator;
    List<Node> squares;
    public GameObject squarePrefab;
    public GameObject grid;
    public int rows;
    public int cols;
    public int obstaclesPercentage;
    public Color startColor;
    public Color endColor;
    public Color pathColor;

    void Start()
    {
        gridGenerator = new GridGenerator(rows, cols, squarePrefab, obstaclesPercentage, grid);
        squares = gridGenerator.GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            gridGenerator.ChangeSquareColor(5, Color.blue, squares);
        }
    }
}
