using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutable : BaseRope
{
    Color StandartColor;
    private void Awake()
    {
        StandartColor = spriteRenderer.color;
    }
    public void Cut()
    {
        nodes[0].RemoveRope(this);
        nodes[1].RemoveRope(this);

        GetCut();
        Destroy(gameObject);
    }

    public bool IsCutable()
    {
        if(nodes[0].GetConnectedRopeCount()<2)
            return false;
        if (nodes[1].GetConnectedRopeCount() < 2)
            return false;
        return true;
    }

    public void ColorCut()
    {
        spriteRenderer.color = Color.green;
    }
    public void ColorUnCutable()
    {
        spriteRenderer.color = Color.red;
    }

    public void ColorStandart()
    {
        spriteRenderer.color = StandartColor;
    }
}
