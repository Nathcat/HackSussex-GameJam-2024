using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllAttackCard", menuName = "Cards/All Attack Card", order = 1)]
public class AllAttackCard : Card
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
        List<Combatant> combatants = FindAnyObjectByType<FightController>().combatants;
        for (int i = 1; i < combatants.Count; i++)
        {
            combatants[i].updateHealth(-attackDamage);
        }
    }

}
