using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public static int randomSeed = (int) System.DateTime.Now.TimeOfDay.TotalMilliseconds;
    public Node rootNode;
    public List<List<Node>> levels = new List<List<Node>>();
    private int numberOfLevels;
    private int maxNodesPerLevel;
    private int maxWeight;

    public Graph(int numberOfLevels, int maxNodesPerLevel, int maxWeight) {
        Random.InitState(randomSeed);

        this.numberOfLevels = numberOfLevels;
        this.maxNodesPerLevel = maxNodesPerLevel;
        this.maxWeight = maxWeight;

        for (int i = 0; i < numberOfLevels; i++) {
            List<Node> l = new List<Node>();
            levels.Add(l);

            for (int x = 0; x < Random.Range(1, maxNodesPerLevel); x++) {
                l.Add(new Node());
            }
        }

        rootNode = new Node();
        levels.Insert(0, new List<Node>(new Node[] { rootNode }));     // First level with only one node
        levels.Add(new List<Node>(new Node[] { new Node() }));          // Final level with the mothership node

        // All levels now populated with nodes
        // Link a random number of nodes in each level to a random node in the next level

        int numberOfPaths = Random.Range(1, levels[1].Count);
        for (int i = 0; i < numberOfPaths; i++) {
            generatePath(rootNode, levels, 0);
        }

        // Clean up nodes which have not been linked into the graph
        for (int L = 0; L < levels.Count; L++) {
            for (int i = 0; i < levels[L].Count; i++) {
                if (levels[L][i].backwardsEdges.Count == 0) {
                    levels[L].RemoveAt(i);
                    L--;
                    break;
                }
            }
        }
    }

    public void generatePath(Node n, List<List<Node>> levels, int L) {
        List<Node> targets = new List<Node>(levels[L]);

        List<Node> shuffledTargets = new List<Node>();
        for (int i = 0; i < targets.Count; i++) {
            int x = Random.Range(0, targets.Count);
            shuffledTargets.Add(targets[x]);
            targets.RemoveAt(x);
        }

        Node target = null;
        for (int i = 0; i < shuffledTargets.Count; i++) {
            target = shuffledTargets[i];
            if (n.getEdge(target) == null) break;
        }

        if (target != null) {
            Edge forward = new Edge(Random.Range(1, this.maxWeight), n, target);
            Edge backward = new Edge(0, target, n);
            n.edges.Add(forward);
            target.backwardsEdges.Add(backward);
        }
        else {
            return;
        }

        if ((L + 1) == levels.Count) {
            return;
        }
        else {
            generatePath(target, levels, L + 1);
        }
    }
}
