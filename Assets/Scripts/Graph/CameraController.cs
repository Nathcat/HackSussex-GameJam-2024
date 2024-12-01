using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GraphRenderer graphRenderer;
    public GameObject targetNode;
    public int fuel = 10;
    public Canvas canvas;

    public void Start() {
        targetNode = graphRenderer.graph.rootNode.obj;
    }

    public void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject.CompareTag("Node")) {
                if (hit.collider.gameObject == targetNode) {
                    SceneManager.LoadScene("FightScene");
                }

                foreach (Edge e in targetNode.GetComponent<NodeComponent>().node.edges) {
                    if (e.B.obj == hit.collider.gameObject) {
                        if (fuel >= e.weight) {
                            canvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Moving to this ship will require <b><i>" + e.weight + "</i></b> fuel.\n\nContinue?";
                            canvas.transform.GetChild(1).gameObject.SetActive(true);
                            canvas.transform.GetChild(2).gameObject.SetActive(true);
                            canvas.transform.GetChild(3).gameObject.SetActive(false);
                            
                            canvas.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate {
                                targetNode = hit.collider.gameObject;
                                fuel -= e.weight;
                                canvas.gameObject.SetActive(false);
                            });

                            canvas.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate {
                                canvas.gameObject.SetActive(false);
                            });

                            canvas.gameObject.SetActive(true);
                        }
                        else {
                            canvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Moving to this ship will require <b><i>" + e.weight + "</i></b> fuel.\n\nYou don't have enough fuel!";
                            canvas.transform.GetChild(1).gameObject.SetActive(false);
                            canvas.transform.GetChild(2).gameObject.SetActive(false);
                            canvas.transform.GetChild(3).gameObject.SetActive(true);

                            canvas.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate {
                                canvas.gameObject.SetActive(false);
                            });

                            canvas.gameObject.SetActive(true);
                        }
                    }
                }

                foreach (Edge e in targetNode.GetComponent<NodeComponent>().node.backwardsEdges) {
                    if (e.B.obj == hit.collider.gameObject) {
                        if (fuel >= e.weight) {
                            targetNode = hit.collider.gameObject;
                            fuel -= e.weight;
                        }
                        else {
                            Debug.LogError("Not enough fuel! Do some UI thing here?");
                        }
                    }
                }
            }
        }

        UpdateCameraPosition();
    }

    public void UpdateCameraPosition() {
        Vector3 targetPosition = new Vector3(targetNode.transform.position.x, targetNode.transform.position.y, -20f);
        Vector3 difference = targetPosition - transform.position;
        
        transform.Translate(difference * 0.1f);
    }

    public void LoadLevel() {
        SceneManager.LoadScene("FightScene");
    }
}
