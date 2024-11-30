using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    [SerializeField] private float framePeriod;

    private SpriteRenderer spriteRenderer;
    private float frameTime = 0;
    private int frameIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = frames[0];
    }

    void Update()
    {
        frameTime += Time.deltaTime;
        if (frameTime >= framePeriod)
        {
            frameIndex++;
            frameTime = 0;
            if (frameIndex >= frames.Length) frameIndex = 0;
            spriteRenderer.sprite = frames[frameIndex];
        }
    }
}
