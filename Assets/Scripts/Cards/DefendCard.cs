using UnityEngine;

[CreateAssetMenu(fileName = "DefendCard", menuName = "Cards/Defend Card", order = 1)]
public class DefendCard : Card
{
    [SerializeField] private int defencePoints;

    public override int GetStat()
    {
        return defencePoints;
    }

    public override bool IsSelf()
    {
        return true;
    }

    protected override void PlayCard(Combatant combatant)
    {
        combatant.updateDefence(defencePoints);
    }

    
}
