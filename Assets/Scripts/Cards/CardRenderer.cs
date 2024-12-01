using System;
using TMPro;
using UnityEngine;

public class CardRenderer : MonoBehaviour
{
    [SerializeField] private References references;
    [SerializeField] private float enlargeAmount;
    [SerializeField] private Card card;
    
    private bool enlarged = false;
    private Collider collider;
    private Vector3 position;
    private Vector3 scale;
    private PlayerController playerController;

    private void Start()
    {
        position = transform.position;
        scale = transform.localScale;
        collider = GetComponent<Collider>();
        playerController = FindObjectOfType<PlayerController>();
        Render(card);
    }

    private void OnMouseEnter()
    {
        enlarged = true;
    }

    private void OnMouseExit()
    {
        enlarged = false;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, scale * (enlarged ? enlargeAmount : 1), Time.deltaTime * 5);
        if (collider.enabled) transform.position = Vector3.Lerp(transform.position, enlarged ? new Vector3(position.x, -1, position.z - 0.1f) : position, Time.deltaTime * 5);
        references.background.color = new Color(80, 41, 41);
    }

    public Card GetCard() { return card; }

    public void Render(Card card)
    {
        this.card = card;

        references.background.sprite = card.GetBackground();
        references.title.text = card.GetTitle();
        references.description.text = card.GetDescription();
        references.cost.text = "F(N) = " + card.GetTimeCost().ToString();
        references.icon.sprite = card.GetIcon();
        references.stat.text = card.GetStat().ToString();
    }

    [Serializable]
    public struct References
    {
        public SpriteRenderer background;
        public TextMeshPro title;
        public TextMeshPro description;
        public TextMeshPro cost;
        public TextMeshPro stat;
        public SpriteRenderer icon;
    }
}
