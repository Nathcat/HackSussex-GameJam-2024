using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] aliveFrames;
    [SerializeField] private Sprite[] deadFrames;
    [SerializeField] private float framePeriod;

    private SpriteRenderer spriteRenderer;
    private Combatant combatant;
    private float frameTime = 0;
    private int frameIndex = 0;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        combatant = GetComponent<Combatant>();
        spriteRenderer.sprite = aliveFrames[0];
    }

    void Update()
    {
        Sprite[] sprites = (combatant != null && combatant.getHealth() <= 0 ? deadFrames : aliveFrames);

        frameTime += Time.deltaTime;
        if (frameTime >= framePeriod)
        {
            frameIndex++;
            frameTime = 0;
            if (frameIndex >= sprites.Length) frameIndex = 0;
            spriteRenderer.sprite = sprites[frameIndex];
        }
    }
}
