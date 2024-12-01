using UnityEngine;

[CreateAssetMenu(fileName = "SiphonCard", menuName = "Cards/Siphon Card", order = 1)]
public class SiphonCard : Card
{
    [SerializeField] private int damage;
    [SerializeField] private int energy;

    public override int GetStat()
    {
        return energy;
    }

    public override bool IsSelf()
    {
        return true;
    }

    protected override void PlayCard(Combatant combatant)
    {
        combatant.updateHealth(-damage);
        combatant.updateEnergy(energy);
    }


}
