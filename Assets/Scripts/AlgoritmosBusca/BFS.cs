using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// BFS (Breadth First Search) � um algoritmo de busca em largura que percorre todos os n�s de um grafo
/// Este exemplo aplica o algoritmo em um grid 2D
/// </summary>
public class BFS
{
    // Refer�ncia � lista de n�s
    public List<Node> squares;
    Color pathColor;

    // Inicia a busca em largura e, ap�s a conclus�o, visualiza o caminho
    public void RunBFS(Node startNode, Node destinationNode, List<Node> nodes, Color color)
    {
        pathColor = color;
        squares = nodes;
        BuscaLargura(startNode);
        VisualizarCaminho(destinationNode);
    }

    // M�todo para realizar a busca em largura
    public void BuscaLargura(Node startNode)
    {
        foreach (var node in squares)
        {
            node.visited = false;
            node.distance = Mathf.Infinity;
            node.previousNode = null;
        }

        // Marca o n� inicial como visitado e define sua dist�ncia como 0
        startNode.visited = true;
        startNode.distance = 0;

        // Cria uma fila para gerenciar os n�s a serem visitados
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(startNode);

        // Enquanto a fila n�o estiver vazia, continua a busca
        while (queue.Count > 0)
        {
            // Remove o n� da fila
            Node currentNode = queue.Dequeue();
            foreach (var neighbor in currentNode.neighbors)
            {
                // Se o vizinho n�o foi visitado e n�o � um obst�culo, calcula a dist�ncia e o enfileira
                if (!neighbor.visited && !neighbor.isObstacle)
                {
                    neighbor.visited = true;
                    neighbor.distance = currentNode.distance + 1;
                    neighbor.previousNode = currentNode;
                    queue.Enqueue(neighbor);
                }
            }
        }

        Debug.Log("Busca em largura realizada com sucesso");
    }

    // M�todo para visualizar o caminho (opcional)
    public void VisualizarCaminho(Node destino)
    {
        Node currentNode = destino;
        while (currentNode != null)
        {
            // Altera a cor do quadrado para indicar o caminho
            currentNode.square.GetComponent<SpriteRenderer>().color = pathColor;
            currentNode = currentNode.previousNode;
        }
    }
}
