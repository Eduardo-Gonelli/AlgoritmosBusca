using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridGenerator gridGenerator;
    List<Node> squares;
    public GameObject squarePrefab;
    public GameObject grid;
    [Header("Grid Settings - Cuidado ao colocar valores muito altos!")]
    [Range(10, 200)]
    public int rows;
    [Range(10, 200)]
    public int cols;
    [Range(0, 50)]
    public int obstaclesPercentage;
    public Color startColor;
    public Color endColor;
    public Color pathColor;
    public CameraManager cameraManager;
    BFS bfs;

    void Start()
    {
        gridGenerator = new GridGenerator(rows, cols, squarePrefab, obstaclesPercentage, grid);
        squares = gridGenerator.GenerateGrid();
        cameraManager.AdjustCamera(grid);
        bfs = new BFS();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            gridGenerator.ChangeSquareColor(5, Color.blue, squares);
        }
    }

    public void RunSearch(Node startNode, Node destinationNode, SearchType searchType)
    {
        switch(searchType)
        {
            case SearchType.BFS:
                bfs.RunBFS(startNode, destinationNode, squares);
                break;
            case SearchType.DFS:
                Debug.Log("DFS");
                break;
            case SearchType.Dijkstra:
                Debug.Log("Dijkstra");
                break;
            case SearchType.AStar:
                Debug.Log("A*");
                break;
        }        
    }
}
