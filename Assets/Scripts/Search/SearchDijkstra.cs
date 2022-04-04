using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Priority_Queue;

public static class SearchDijkstra
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
        bool found = false;

        SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();

        source.Cost = 0;
        nodes.Enqueue(source, source.Cost);

        int steps = 0;
        while (!found && nodes.Count > 0 && steps++ < maxSteps)
        {
            GraphNode node = nodes.Dequeue();
            if (node == destination)
            {
                found = true;
                continue;
            }

            foreach (GraphNode.Edge edge in node.Edges)
            {
                float cost = node.Cost + Vector3.Distance(edge.nodeA.transform.position, edge.nodeB.transform.position);
                if (cost < edge.nodeB.Cost)
                {
                    edge.nodeB.Cost = cost;
                    edge.nodeB.parent = node;
                    nodes.Enqueue(edge.nodeB, edge.nodeB.Cost);
                }
            }
        }
        // create a list of graph nodes (path)
        path = new List<GraphNode>();
        // if found is true
        if (found)
        {
            GraphNode node = destination;
            // while node not null
            while (node != null)
            {
                // <add node to path list>
                path.Add(node);
                // <set node to node.Parent>
                node = node.parent;
            }
            path.Reverse();
        }
        else
        {
            // add all nodes to path
            while (nodes.Count > 0)
            {
                // <add (dequeued node) to path>
                path.Add(nodes.Dequeue());
            }
        }
        return found;
    }
}