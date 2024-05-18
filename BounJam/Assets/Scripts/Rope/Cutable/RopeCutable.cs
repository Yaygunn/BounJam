using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutable : BaseRope
{
    public void Cut()
    {
        nodes[0].RemoveRope(this);
        nodes[1].RemoveRope(this);
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
}
