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
        return false;
    }

    protected override void PlayCard(Combatant combatant)
    {
        GameObject hand = GameObject.Find("FightController");
        hand.GetComponent<HandOrganiser>().Generate(hand.GetComponent<HandOrganiser>().hold_gen);
    }

}
