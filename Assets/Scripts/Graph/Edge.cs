using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public int weight;
    public Node A;
    public Node B;

    public Edge(int w, Node A, Node B) {
        this.weight = w;
        this.A = A;
        this.B = B;
    }
}
