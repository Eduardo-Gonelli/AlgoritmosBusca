using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    // Referência à lista de nós
    public List<Node> squares;
    Color pathColor;

    // Cria uma lista para nós ainda não visitados
    List<Node> openList = new List<Node>();


    // Inicia o algoritmo de Dijkstra e, após a conclusão, visualiza o caminho
    public void RunDijkstra(Node startNode, Node destinationNode, List<Node> nodes, Color color)
    {
        pathColor = color;
        squares = nodes;

        // Inicialização
        foreach (var node in squares)
        {
            node.distance = Mathf.Infinity; 
            // -----------------------------------------------------------
            // ativar a linha abaixo para setar o cost randomicamente.
            // Só vai funcionar no Dijkistra
            // assim o Dijkistra encontra o menor caminho baseado no custo
            // Se não tiver essa linha, o Dijkistra vai se comportar como o BFS
            // node.cost = Random.Range(0.0f, 2.0f);
            // -----------------------------------------------------------
            node.previousNode = null;
            node.visited = false;
            openList.Clear();
        }

        startNode.distance = 0;
        openList.Add(startNode);


        while (openList.Count > 0)
        {
            // Encontra o nó com a menor distância na openList
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

            // Remove o nó atual da lista aberta
            openList.Remove(currentNode);

            // Se o nó atual é o nó destino
            if (currentNode == destinationNode)
            {
                break;
            }

            // Explora os vizinhos do nó atual
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

            // Marca o nó atual como visitado após explorar todos os vizinhos
            currentNode.visited = true;
        }

        // Após concluir a busca, visualiza o caminho
        VisualizarCaminho(destinationNode);
    }

    // Método para visualizar o caminho (opcional)
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
