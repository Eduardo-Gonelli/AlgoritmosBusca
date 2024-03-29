using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DFS (Depth First Search) � um algoritmo de busca em profundidade que percorre todos os n�s de um grafo
/// Este exemplo aplica o algoritmo em um grid 2D
/// </summary>
public class DFS
{
    // Refer�ncia � lista de n�s
    public List<Node> squares;
    Color pathColor;

    // Inicia a busca em profundidade e, ap�s a conclus�o, visualiza o caminho
    public void RunDFS(Node startNode, Node destinationNode, List<Node> nodes, Color color)
    {
        pathColor = color;
        squares = nodes;
        foreach (Node node in squares)
        {
            node.visited = false;
            node.previousNode = null;
        }
        BuscaProfundidade(startNode, destinationNode);
        VisualizarCaminho(destinationNode);
    }

    // M�todo para realizar a busca em profundidade
    private void BuscaProfundidade(Node currentNode, Node destinationNode)
    {
        // Marca o n� atual como visitado
        currentNode.visited = true;
        // Se o n� atual � o destino, encerra a busca
        if (currentNode == destinationNode)
        {
            Debug.Log("Destino alcan�ado na busca em profundidade");
            return;
        }
        else
        {
            // Para cada vizinho do n� atual
            foreach (var neighbor in currentNode.neighbors)
            {
                // Se o vizinho n�o foi visitado e n�o � um obst�culo
                if (!neighbor.visited && !neighbor.isObstacle)
                {
                    // Marca o vizinho como visitado, define o n� atual como anterior e chama a busca recursivamente
                    neighbor.previousNode = currentNode;
                    BuscaProfundidade(neighbor, destinationNode);
                }
            }
        }


    }

    // M�todo para visualizar o caminho (opcional)
    private void VisualizarCaminho(Node destino)
    {
        Node currentNode = destino;
        while (currentNode != null)
        {
            currentNode.square.GetComponent<SpriteRenderer>().color = pathColor;
            currentNode = currentNode.previousNode;
        }
    }
}
