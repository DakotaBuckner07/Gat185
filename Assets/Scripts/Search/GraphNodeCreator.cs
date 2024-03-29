﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeCreator : MonoBehaviour
{
    public GraphNode graphNode;
    public LayerMask layerMask;
    public float range = 1.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
            {
                GraphNode node = Instantiate(graphNode, hitInfo.point, Quaternion.identity);
                GraphNode.UnlinkNodes();
                GraphNode.LinkNodes(range);
            }
        }
    }


    public void LinkNodes()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject gameObject in gameObjects)
        {
            GraphNode graphNode = gameObject.GetComponent<GraphNode>();
            if (graphNode != null)
            {
                GraphNode.LinkNode(graphNode, range);
            }
        }
    }

}
