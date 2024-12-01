using UnityEngine;

[CreateAssetMenu(fileName = "AttackCard", menuName = "Cards/Attack Card", order = 1)]
public class AttackCard : Card
{
    [SerializeField] private int attackDamage;

    public override int GetStat()
    {
        return attackDamage;
    }

    public override void Play(Combatant combatant)
    {
        combatant.updateHealth(-attackDamage);
    }

}
