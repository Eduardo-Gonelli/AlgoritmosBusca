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
        distance = Random.Range(0.0f, 2.0f);
        // -----------------------------------------------------------
        // ativar a linha abaixo para setar o cost randomicamente.
        // S� vai funcionar no Dijkistra e no A*
        // assim o Dijkistra encontra o menor caminho baseado no custo
        // Se n�o tiver essa linha, o Dijkistra vai se comportar como o BFS
        cost = Random.Range(0.0f, 3.0f);
        // -----------------------------------------------------------
    }
}
