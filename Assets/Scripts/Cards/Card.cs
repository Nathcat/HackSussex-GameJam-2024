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

    protected abstract void PlayCard(Combatant combatant);

    public void Play(Combatant combatant)
    {
        AudioSource.PlayClipAtPoint(sound, combatant.transform.position);
        PlayCard(combatant);
    }

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

    public abstract int GetStat();
    
    public abstract bool IsSelf();
}
