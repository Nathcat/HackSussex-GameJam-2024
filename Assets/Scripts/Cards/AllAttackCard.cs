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

    public override void Play(Combatant combatant)
    {
        List<Combatant> combatants = FindAnyObjectByType<FightController>().combatants;
        AudioSource.PlayClipAtPoint(GetSound(), combatant.transform.position);
        for (int i = 1; i < combatants.Count; i++)
        {
            combatants[i].updateHealth(-attackDamage);
            CardAnimation.Play(GetIcon(), combatants[i].transform.position);
        }
    }

}
