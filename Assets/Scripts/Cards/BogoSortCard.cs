using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "BogoSortCard", menuName = "Cards/BogoSortCard", order = 1)]
public class BogoSortCard : Card
{
    [SerializeField] private int attackDamage;
    [SerializeField] private int energy;
    [SerializeField] private int defencePoints;
    public override int GetStat()
    {
        return attackDamage;
    }
    public void playagain(Combatant combatant) {
        GameObject hand = GameObject.Find("FightController");
        FightController fightController = hand.GetComponent<FightController>();
        fightController.combatants[fightController.currentCombatant].playCard(this, combatant);

    }
    public override bool IsSelf()
    {
        return false;
    }
    public override void Play(Combatant combatant)
    {
        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<Combatant>().getEnergy() != 0)
        {
            Debug.Log("ran bogo sort");
            int random = Random.Range(0, 100);
            energy = Random.Range(1, 5);
            attackDamage = Random.Range(1, 10);
            defencePoints = Random.Range(1, 10);

            if (random >= 0 && random < 10)
            {
                //no more
            }
            else if (random >= 10 && random < 40)
            {
                combatant.updateHealth(-attackDamage);
                playagain(combatant);
            }
            else if (random >= 40 && random < 70)
            {
                player.gameObject.GetComponent<Combatant>().updateDefence(defencePoints);
                playagain(combatant);
            }
            else if (random >= 70 && random < 80)
            {
                player.gameObject.GetComponent<Combatant>().updateHealth(attackDamage / 2);
                player.gameObject.GetComponent<Combatant>().updateEnergy(energy);
                playagain(combatant);
            }
            else if (random >= 80 && random < 90)
            {
                GameObject hand = GameObject.Find("FightController");
                player.GetComponent<Combatant>().createDeck(hand.GetComponent<FightController>().playerCardSet,7);
                GameObject bal = GameObject.Find("Hand(Clone)");
                bal.gameObject.GetComponent<HandOrganiser>().Generate(player.gameObject.GetComponent<Combatant>().getDeck().ToList<Card>());

            }
            else if (random >= 90 && random <= 100)
            {
                List<Combatant> combatants = FindAnyObjectByType<FightController>().combatants;
                for (int i = 1; i < combatants.Count; i++)
                {
                    combatants[i].updateHealth(-attackDamage);


                }
                playagain(combatant);
            }
        }
    }
}

