using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject
{
    // Attributes
    [SerializeField] private int timeCost;

    // Display info
    [SerializeField] private Sprite background;
    [SerializeField] private Sprite icon;
    [SerializeField] private string title;
    [SerializeField] private string description;

    public int getTimeCost()
    {
        return timeCost;
    }

    public Sprite getBackground()
    {
        return background;
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public string getTitle()
    {
        return title;
    }

    public string getDescription()
    {
        return description;
    }
}
