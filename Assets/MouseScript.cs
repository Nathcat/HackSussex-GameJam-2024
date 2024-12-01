using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class MouseScript : MonoBehaviour
{
    [SerializeField]private bool card_held = false;
    // Start is called before the first frame update
    [SerializeField] private Vector3 dir;
    [SerializeField] private Vector3 card_origin;
    [SerializeField] private GameObject card = null;
    [SerializeField] private Vector3 mouse_position;
    [SerializeField] GameObject hand = null;

    // Update is called once per frame
    void Update()
    {
        hand = GameObject.Find("FightController");
        if (hand.GetComponent<FightController>().combatants.Count == 0) 
        {
            card.transform.position = card_origin;
            card_held = false;
            card.gameObject.GetComponent<Collider>().enabled = true;
            card = null;
        }

        dir =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f)) - Camera.main.transform.position;
        RaycastHit hit;

       if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.transform.position, dir, out hit, Mathf.Infinity) && (hand.GetComponent<FightController>().combatants.Count != 0)
)
        {
            if (hit.collider.gameObject.CompareTag("combatant") && card != null)
            {
                Card cardClass = card.GetComponent<CardRenderer>().GetCard();
                FightController fightController = hand.GetComponent<FightController>();
                cardClass.Play(hit.collider.gameObject.GetComponent<Combatant>());
                fightController.handPrefab.GetComponent<HandOrganiser>().funky_store.Remove(card);
                fightController.combatants[fightController.currentCombatant].playCard(cardClass);
                Destroy(card);
  
                card_held = false;
                card = null;

                fightController.handPrefab.GetComponent<HandOrganiser>().Generate(fightController.combatants[fightController.currentCombatant].getDeck().ToList());
                
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
            card.transform.position = mouse_position;
        }
    }


}
