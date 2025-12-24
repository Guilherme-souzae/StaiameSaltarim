using UnityEngine;

public class ColorShift : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public float colorCycleSpeed = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float hue = Mathf.Repeat(Time.time * colorCycleSpeed, 1f);
        Color color = Color.HSVToRGB(hue, 1f, 1f);
        spriteRenderer.color = color;
    }
}
