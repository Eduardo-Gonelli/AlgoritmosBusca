using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    // Refer�ncia � lista de n�s
    public List<Node> squares;
    public Color pathColor;

    // Define a classe NodeRecord internamente para controlar as informa��es adicionais necess�rias
    private class NodeRecord
    {
        public Node node;
        public Node connection; // De onde veio
        public float costSoFar;
        public float estimatedTotalCost;

        public NodeRecord(Node node)
        {
            this.node = node;
            this.connection = null;
            this.costSoFar = 0;
            this.estimatedTotalCost = Mathf.Infinity;
        }
    }

    // Fun��o heur�stica para estimar a dist�ncia at� o destino
    private float Heuristic(Node a, Node b)
    {
        return Vector2Int.Distance(a.gridPosition, b.gridPosition);
    }

    // Executa o algoritmo A*
    public void RunAStar(Node startNode, Node destinationNode, List<Node> nodes, Color color)
    {
        pathColor = color;
        squares = nodes;

        Dictionary<Node, NodeRecord> nodeRecords = new Dictionary<Node, NodeRecord>();
        List<NodeRecord> open = new List<NodeRecord>();
        List<NodeRecord> closed = new List<NodeRecord>();

        NodeRecord startRecord = new NodeRecord(startNode);
        startRecord.costSoFar = 0;
        startRecord.estimatedTotalCost = Heuristic(startNode, destinationNode);
        open.Add(startRecord);
        nodeRecords[startNode] = startRecord;

        while (open.Count > 0)
        {
            NodeRecord currentRecord = open[0];
            foreach (var record in open)
            {
                if (record.estimatedTotalCost < currentRecord.estimatedTotalCost)
                {
                    currentRecord = record;
                }
            }

            if (currentRecord.node == destinationNode)
            {
                break;
            }

            foreach (Node neighbor in currentRecord.node.neighbors)
            {
                if (neighbor.isObstacle) continue;

                float endNodeCost = currentRecord.costSoFar + neighbor.cost;
                NodeRecord endNodeRecord;

                if (nodeRecords.ContainsKey(neighbor))
                {
                    endNodeRecord = nodeRecords[neighbor];
                    if (endNodeRecord.costSoFar <= endNodeCost) continue;
                }
                else
                {
                    endNodeRecord = new NodeRecord(neighbor);
                    nodeRecords[neighbor] = endNodeRecord;
                }

                endNodeRecord.costSoFar = endNodeCost;
                endNodeRecord.connection = currentRecord.node;
                endNodeRecord.estimatedTotalCost = endNodeCost + Heuristic(neighbor, destinationNode);

                if (!open.Contains(endNodeRecord))
                {
                    open.Add(endNodeRecord);
                }
            }

            open.Remove(currentRecord);
            closed.Add(currentRecord);
        }

        // Recria o caminho at� o destino
        if (nodeRecords.ContainsKey(destinationNode))
        {
            NodeRecord current = nodeRecords[destinationNode];
            while (current.node != startNode)
            {
                current.node.square.GetComponent<SpriteRenderer>().color = pathColor;
                current = nodeRecords[current.connection];
            }
        }
    }
}
