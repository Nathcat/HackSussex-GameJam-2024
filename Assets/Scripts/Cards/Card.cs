using UnityEngine;

public abstract class Card : ScriptableObject
{
    // Attributes
    [SerializeField] private int timeCost;

    // Display info
    [SerializeField] private Sprite icon;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private AudioClip sound;

    public abstract void Play(Combatant combatant);

    public int GetTimeCost()
    {
        return timeCost;
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

    public AudioClip GetSound()
    {
        return sound;
    }

    public abstract int GetStat();
    
    public abstract bool IsSelf();
}
