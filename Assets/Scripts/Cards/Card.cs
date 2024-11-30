using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a base card with no effect
/// </summary>
[CreateAssetMenu(fileName = "Card", menuName = "Cards/Card", order = 1)]
public class Card : ScriptableObject
{
    // Attributes
    public int timeCost;

    // Display info
    public Sprite background;
    public Sprite icon;
    public string description;
}
