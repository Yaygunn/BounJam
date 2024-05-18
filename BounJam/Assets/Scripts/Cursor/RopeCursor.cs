using UnityEngine;

public class RopeCursor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color standartColor;
    private Color correctColor = Color.green;
    private Color failColor = Color.red;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        standartColor = spriteRenderer.color;
    }
    public void StardartColor()
    {
        spriteRenderer.color = standartColor;
    }

    public void CorrectColor()
    {
        spriteRenderer.color = correctColor;
    }

    public void FailColor()
    {
        spriteRenderer.color = failColor;
    }
}
