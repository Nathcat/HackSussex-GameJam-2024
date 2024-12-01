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

    public abstract void Play(Combatant combatant);

    public int GetTimeCost()
    {
        return timeCost;
    }

    public Sprite GetBackground()
    {
        return background;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetDescription()
    {
        return description;
    }

    public abstract int GetStat();
    
    public abstract bool IsSelf();
}
