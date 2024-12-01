using UnityEngine;

[CreateAssetMenu(fileName = "AttackCard", menuName = "Cards/Attack Card", order = 1)]
public class AttackCard : Card
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
        AudioSource.PlayClipAtPoint(GetSound(),combatant.transform.position);
        CardAnimation.Play(GetIcon(), combatant.transform.position);
        combatant.updateHealth(-attackDamage);
    }

}
