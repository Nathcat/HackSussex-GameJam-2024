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
    public GameObject canvas;
    public TMP_Text fuelText;
    public GameObject nodeBorderPrefab;
    private GameObject currentNodeBorder;

    public void Start() {
        if (PlayerPrefs.HasKey("InitFuel")) {
            fuel = PlayerPrefs.GetInt("InitFuel");
            PlayerPrefs.DeleteKey("InitFuel");
        }

        if (PlayerPrefs.HasKey("AddFuel")) {
            fuel = Mathf.Min(fuel + PlayerPrefs.GetInt("AddFuel"), 10);
            PlayerPrefs.DeleteKey("AddFuel");
        }

        if (PlayerPrefs.HasKey("InitTargetLevel") && PlayerPrefs.HasKey("InitTargetIndex")) {
            int level = PlayerPrefs.GetInt("InitTargetLevel");
            int index = PlayerPrefs.GetInt("InitTargetIndex");
            targetNode = graphRenderer.graph.levels[level][index].obj;
        }
        else {
            targetNode = graphRenderer.graph.rootNode.obj;
            currentNodeBorder = Instantiate(nodeBorderPrefab, Vector3.zero, new Quaternion());
            currentNodeBorder.transform.SetParent(targetNode.transform, false);
        }
    }

    public void Update() {
        fuelText.text = "Fuel: " + fuel;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject.CompareTag("Node")) {
                /*if (hit.collider.gameObject == graphRenderer.graph.levels[graphRenderer.graph.levels.Count - 1][0].obj) {
                    SceneManager.LoadScene("WinScene");
                    PlayerPrefs.DeleteAll();
                    return;
                }*/

                if (hit.collider.gameObject == targetNode) {
                    /*PlayerPrefs.SetInt("InitFuel", fuel);
                    PlayerPrefs.SetInt("InitTargetLevel", targetNode.GetComponent<NodeComponent>().level);
                    PlayerPrefs.SetInt("InitTargetIndex", targetNode.GetComponent<NodeComponent>().index);
                    SceneManager.LoadScene("FightScene");*/
                    return;
                }

                foreach (Edge e in targetNode.GetComponent<NodeComponent>().node.edges) {
                    if (e.B.obj == hit.collider.gameObject) {
                        if (fuel >= e.weight) {
                            canvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Moving to this ship will require <b><i>" + e.weight + "</i></b> fuel.\n\nContinue?";
                            canvas.transform.GetChild(1).gameObject.SetActive(true);
                            canvas.transform.GetChild(2).gameObject.SetActive(true);
                            canvas.transform.GetChild(3).gameObject.SetActive(false);
                            canvas.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
                            canvas.transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
                            canvas.transform.GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();

                            canvas.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate {
                                targetNode = hit.collider.gameObject;
                                fuel -= e.weight;
                                canvas.gameObject.SetActive(false);

                                if (currentNodeBorder != null) {
                                    Destroy(currentNodeBorder);
                                }

                                currentNodeBorder = Instantiate(nodeBorderPrefab, Vector3.zero, new Quaternion());
                                currentNodeBorder.transform.SetParent(targetNode.transform, false);
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
                            canvas.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
                            canvas.transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
                            canvas.transform.GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();

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
                            canvas.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Moving to this ship will require <b><i>" + e.weight + "</i></b> fuel.\n\nContinue?";
                            canvas.transform.GetChild(1).gameObject.SetActive(true);
                            canvas.transform.GetChild(2).gameObject.SetActive(true);
                            canvas.transform.GetChild(3).gameObject.SetActive(false);
                            
                            canvas.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate {
                                targetNode = hit.collider.gameObject;
                                fuel -= e.weight;
                                canvas.gameObject.SetActive(false);

                                if (currentNodeBorder != null) {
                                    Destroy(currentNodeBorder);
                                }

                                currentNodeBorder = Instantiate(nodeBorderPrefab, Vector3.zero, new Quaternion());
                                currentNodeBorder.transform.SetParent(targetNode.transform, false);
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
            }
        }

        UpdateCameraPosition();
    }

    public void UpdateCameraPosition() {
        Vector3 targetPosition = new Vector3(targetNode.transform.position.x, targetNode.transform.position.y, -15f);
        Vector3 difference = targetPosition - transform.position;
        
        transform.Translate(difference * 0.1f);
    }

    public void LoadLevel() {
        PlayerPrefs.SetInt("InitFuel", fuel);
        PlayerPrefs.SetInt("InitTargetLevel", targetNode.GetComponent<NodeComponent>().level);
        PlayerPrefs.SetInt("InitTargetIndex", targetNode.GetComponent<NodeComponent>().index);

        if (targetNode.GetComponent<NodeComponent>().level == (graphRenderer.graph.levels.Count - 1)) {
            Debug.LogError("This would be the boss scene!");
            PlayerPrefs.DeleteAll();
        }
        else {
            SceneManager.LoadScene("FightScene");
        }
    }
}
