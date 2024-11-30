using System;
using TMPro;
using UnityEngine;

public class CardRenderer : MonoBehaviour
{
    [SerializeField] private Card card;
    [SerializeField] private References references;

    private void Start()
    {
        Render(card);
    }

    public Card GetCard() { return card; }

    public void Render(Card card)
    {
        this.card = card;

        references.background.sprite = card.GetBackground();
        references.title.text = card.GetTitle();
        references.description.text = card.GetDescription();
        references.cost.text = card.GetTimeCost().ToString();
    }

    [Serializable]
    public struct References
    {
        public SpriteRenderer background;
        public TextMeshPro title;
        public TextMeshPro description;
        public TextMeshPro cost;
    }
}