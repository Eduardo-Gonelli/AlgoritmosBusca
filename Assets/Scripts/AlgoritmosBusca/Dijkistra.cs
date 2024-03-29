using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    // Refer�ncia � lista de n�s
    public List<Node> squares;
    Color pathColor;

    // Cria uma lista para n�s ainda n�o visitados
    List<Node> openList = new List<Node>();


    // Inicia o algoritmo de Dijkstra e, ap�s a conclus�o, visualiza o caminho
    public void RunDijkstra(Node startNode, Node destinationNode, List<Node> nodes, Color color)
    {
        pathColor = color;
        squares = nodes;

        // Inicializa��o
        foreach (var node in squares)
        {
            node.distance = Mathf.Infinity; 
            node.previousNode = null;
            node.visited = false;
            openList.Clear();
        }

        startNode.distance = 0;
        openList.Add(startNode);


        while (openList.Count > 0)
        {
            // Encontra o n� com a menor dist�ncia na openList
            Node currentNode = null;
            float smallestDistance = Mathf.Infinity;
            foreach (Node node in openList)
            {
                if (node.distance < smallestDistance)
                {
                    smallestDistance = node.distance;
                    currentNode = node;
                }
            }

            // Remove o n� atual da lista aberta
            openList.Remove(currentNode);

            // Se o n� atual � o n� destino
            if (currentNode == destinationNode)
            {
                break;
            }

            // Explora os vizinhos do n� atual
            foreach (Node neighbor in currentNode.neighbors)
            {
                if (!neighbor.isObstacle && !neighbor.visited)
                {
                    float tentativeDistance = currentNode.distance + neighbor.cost;
                    if (tentativeDistance < neighbor.distance)
                    {
                        neighbor.distance = tentativeDistance;
                        neighbor.previousNode = currentNode;

                        if (!openList.Contains(neighbor))
                        {
                            openList.Add(neighbor);
                        }
                    }
                }
            }

            // Marca o n� atual como visitado ap�s explorar todos os vizinhos
            currentNode.visited = true;
        }

        // Ap�s concluir a busca, visualiza o caminho
        VisualizarCaminho(destinationNode);
    }

    // M�todo para visualizar o caminho (opcional)
    private void VisualizarCaminho(Node destinationNode)
    {
        Node currentNode = destinationNode;
        while (currentNode != null)
        {
            currentNode.square.GetComponent<SpriteRenderer>().color = pathColor;
            currentNode = currentNode.previousNode;
        }
    }
}
