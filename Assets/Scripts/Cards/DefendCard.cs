using UnityEngine;

[CreateAssetMenu(fileName = "DefendCard", menuName = "Cards/Defend Card", order = 1)]
public class DefendCard : Card
{
    [SerializeField] private int defencePoints;

    public override void Play(Combatant combatant)
    {
        combatant.updateDefence(defencePoints);
    }
}
