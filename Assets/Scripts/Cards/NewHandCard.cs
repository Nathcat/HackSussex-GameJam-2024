using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "NewHandCard", menuName = "Cards/New Hand Card", order = 1)]
public class NewHandCard : Card
{
    [SerializeField] private int attackDamage;

    public override int GetStat()
    {
        return attackDamage;
    }

    public override bool IsSelf()
    {
        return true;
    }

    public override void Play(Combatant combatant)
    {
        GameObject player = GameObject.Find("Player");
        GameObject hand = GameObject.Find("FightController");
        player.GetComponent<Combatant>().createDeck(hand.GetComponent<FightController>().playerCardSet, 7);
        GameObject bal = GameObject.Find("Hand(Clone)");
        bal.gameObject.GetComponent<HandOrganiser>().Generate(combatant.getDeck().ToList<Card>());
    }

}
