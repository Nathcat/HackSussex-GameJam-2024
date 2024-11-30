using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] aliveFrames;
    [SerializeField] private Sprite[] deadFrames;
    [SerializeField] private float framePeriod;

    private SpriteRenderer spriteRenderer;
    private float frameTime = 0;
    private int frameIndex = 0;

    private Combatant combatant;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        combatant = GetComponent<Combatant>();
        spriteRenderer.sprite = aliveFrames[0];
    }

    void Update()
    {
        frameTime += Time.deltaTime;
        if (frameTime >= framePeriod)
        {
            frameIndex++;
            frameTime = 0;
            if (frameIndex >= aliveFrames.Length) frameIndex = 0;
            spriteRenderer.sprite = (combatant.getHealth() <= 0 ? deadFrames : aliveFrames)[frameIndex];
        }
    }
}
