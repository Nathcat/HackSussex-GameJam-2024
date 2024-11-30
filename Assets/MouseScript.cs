using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    [SerializeField]private bool card_held = false;
    // Start is called before the first frame update
    [SerializeField] private Vector3 dir;
    [SerializeField] private Vector3 card_origin;
    [SerializeField] private GameObject card = null;
    [SerializeField] private float move_speed = 10f;
    [SerializeField] private Vector3 mouse_position;
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
            if (hit.collider.gameObject.CompareTag("combatant"))
            {
                //do function
            }
            else if (hit.collider.gameObject.CompareTag("card") && (!card_held)) 
            {
                if (!card_held) 
                {
                    card_held = true;
                    card = hit.collider.gameObject;
                    card.gameObject.GetComponent<Collider>().enabled = false;
                    card_origin = card.transform.position;
                }
                if (card_held) 
                { 
                    //dont
                }
            }
            else if (hit.collider.gameObject.CompareTag("combatant"))
            {
                //do function
            }

        }
        else if (Input.GetMouseButtonDown(0) && card_held) 
        {
            card.transform.position = card_origin;
            card_held = false; 
            card.gameObject.GetComponent<Collider>().enabled = true;
            card = null;
        }
        if (card_held) 
        {
            mouse_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
            card.transform.position = Vector3.MoveTowards(card.transform.position, mouse_position, move_speed * Time.deltaTime);
        }
    }

}
