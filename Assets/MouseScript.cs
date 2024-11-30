using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private bool card_held = false;
    // Start is called before the first frame update
    private Vector3 dir;
    private Vector3 card_origin;
    private GameObject card = null;
    [SerializeField] private float move_speed = 1f;
    private Vector3 mouse_position;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        dir =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f)) - Camera.main.transform.position;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.transform.position, dir, out hit, Mathf.Infinity)) 
        {
            if (hit.collider.gameObject.CompareTag("card")) 
            {
                if (!card_held) 
                {
                    card = hit.collider.gameObject;
                    card_held = true;
                }
                if (card_held) 
                { 
                    //dont
                }
            }
            if (hit.collider.gameObject.CompareTag("combatant")) 
            { 
                //do function
            }
        }
        if (card_held) 
        {
            mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            card.transform.position = Vector3.MoveTowards(card.transform.position, mouse_position, move_speed * Time.deltaTime);
        }
    }

}
