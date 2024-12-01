using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public static void Play(Sprite sprite, Vector2 position)
    {
        CardAnimation go = Instantiate(Util.instance.animationPrefab);
        go.transform.position = new Vector3(position.x, position.y, 5);
        go.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(1, 1, 1, 0);
        transform.localScale = Vector3.one * 8; 
    }

    private void Update()
    {
        renderer.color = Color.Lerp(renderer.color, Color.white, Time.deltaTime * 10);
        transform.localScale -= Vector3.one * 8 * Time.deltaTime;

        if (transform.localScale.magnitude < 0.1) Destroy(gameObject);
    }
}
