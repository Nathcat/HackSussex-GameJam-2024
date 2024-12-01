using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    public Graph graph;

    public int numberOfLevels = 1;
    public int maxNodesPerLevel = 5;
    public int maxWeight = 5;

    public GameObject nodePrefab;
    public GameObject edgePrefab;
    public Sprite mothershipSprite;

    void Start()
    {
        if (!PlayerPrefs.HasKey("graph-seed")) {
            PlayerPrefs.SetInt("graph-seed", Random.Range(0, 20));
        }

        graph = new Graph(PlayerPrefs.GetInt("graph-seed"), numberOfLevels, maxNodesPerLevel, maxWeight);

        for (int i = 0; i < graph.levels.Count; i++) {
            for (int x = 0; x < graph.levels[i].Count; x++) {
                graph.levels[i][x].obj = Instantiate(
                    nodePrefab,
                    new Vector3(Random.Range(-5, 5) * 1.5f, (i * 2) - 2, 0f),
                    new Quaternion()
                );

                NodeComponent nc = graph.levels[i][x].obj.AddComponent<NodeComponent>();
                nc.node = graph.levels[i][x];
                nc.level = i;
                nc.index = x;
            }
        }

        graph.levels[graph.levels.Count - 1][0].obj.GetComponent<SpriteRenderer>().sprite = mothershipSprite;

        for (int i = 0; i < graph.levels.Count; i++) {
            for (int x = 0; x < graph.levels[i].Count; x++) {
                renderEdges(graph.levels[i][x]);
            }
        }
    }

    void renderEdges(Node n) {
        foreach (Edge e in n.edges) {
            Vector3 diff = e.B.obj.transform.position - e.A.obj.transform.position;
            
            GameObject rE = Instantiate(
                edgePrefab,
                (e.B.obj.transform.position + e.A.obj.transform.position) / 2,
                Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 90f))
            );
            
            rE.transform.localScale = new Vector3(0.1f, diff.magnitude, 1f);
        }
    }
}
