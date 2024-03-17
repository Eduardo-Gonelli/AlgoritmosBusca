using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject square;
    public Vector2Int gridPosition;
    public float cost = 1f;
    public float distance = Mathf.Infinity;
    public bool visited = false;
    public Node previousNode = null;
    public bool isObstacle = false;
    public List<Node> neighbors = new List<Node>();

    public Node(GameObject square, Vector2Int gridPosition)
    {
        this.square = square;
        this.gridPosition = gridPosition;
    }

    public void AddNeighbor(Node neighbor)
    {
        neighbors.Add(neighbor);
    }
}
