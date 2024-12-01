using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GraphRenderer graphRenderer;
    public GameObject targetNode;

    public void Start() {
        targetNode = graphRenderer.graph.rootNode.obj;
    }

    public void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject.CompareTag("Node")) {
                targetNode = hit.collider.gameObject;
            }
        }

        UpdateCameraPosition();
    }

    public void UpdateCameraPosition() {
        Vector3 targetPosition = new Vector3(targetNode.transform.position.x, targetNode.transform.position.y, -10f);
        Vector3 difference = targetPosition - transform.position;
        
        transform.Translate(difference * 0.1f);
    }
}
