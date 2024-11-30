using UnityEngine;

[CreateAssetMenu(fileName = "DefendCard", menuName = "Cards/Defend Card", order = 1)]
public class DefendCard : Card
{
    [SerializeField] private int defencePoints;
}
