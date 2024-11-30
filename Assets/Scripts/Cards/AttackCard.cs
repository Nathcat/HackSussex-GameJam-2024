using UnityEngine;

[CreateAssetMenu(fileName = "AttackCard", menuName = "Cards/Attack Card", order = 1)]
public class AttackCard : Card
{
    [SerializeField] private int attackDamage;
}
