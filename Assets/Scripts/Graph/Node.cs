using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Edge> edges = new List<Edge>();
    public List<Edge> backwardsEdges = new List<Edge>();
    public GameObject obj;

    public Edge getEdge(Node target) {
        foreach (Edge e in edges) {
            if (e.B == target) {
                return e;
            }
        }

        return null;
    }
}
