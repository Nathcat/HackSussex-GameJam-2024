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

    public void Render(Card card)
    {
        this.card = card;

        references.background.sprite = card.getBackground();
        references.title.text = card.getTitle();
    }

    [Serializable]
    public struct References
    {
        public SpriteRenderer background;
        public TextMeshPro title;
        public TextMeshPro description;
    }
}
