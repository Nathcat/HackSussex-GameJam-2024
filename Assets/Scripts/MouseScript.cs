using System.Linq;
using Unity.Burst.CompilerServices;
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
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, 100) && (hand.GetComponent<FightController>().combatants.Count != 0)
)
        {
            if (hit.collider.gameObject.CompareTag("combatant") && card != null)
            {
                Card cardClass = card.GetComponent<CardRenderer>().GetCard();
                if (cardClass.IsSelf() && !hit.collider.gameObject.TryGetComponent(out PlayerController _)) return;
                FightController fightController = hand.GetComponent<FightController>();
                fightController.handPrefab.GetComponent<HandOrganiser>().funky_store.Remove(card);
                fightController.combatants[fightController.currentCombatant].playCard(cardClass, hit.collider.gameObject.GetComponent<Combatant>());
                Destroy(card);
  
                card_held = false;
                card = null;

                fightController.handPrefab.GetComponent<HandOrganiser>().Generate(fightController.combatants[fightController.currentCombatant].getDeck().ToList());
                
            }
            else if (hit.collider.gameObject.CompareTag("card") && (!card_held)) 
            {
                if (!card_held) 
                {
                    Card cardClass = hit.collider.gameObject.GetComponent<CardRenderer>().GetCard();
                    if (cardClass.GetTimeCost() > playerController.getEnergy()) return;
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
