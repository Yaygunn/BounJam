using System.Collections.Generic;
using UnityEngine;

public class BaseNode : MonoBehaviour
{
    private Dictionary<BaseRope, Vector2> RopeDictionary = new Dictionary<BaseRope, Vector2>();
    [SerializeField] int count;

    private void Start()
    {
        foreach (var rope in RopeDictionary.Keys)
        {
            if(rope == null)
            {
                RemoveRope(rope);
                continue;
            }

            BaseNode[] nodes = rope.GetNodes();
            if (nodes[0] != this && nodes[1] != this)
                RemoveRope(rope);
        }
        ShowCount();
    }

    public void AddRope(BaseRope rope)
    {
        if (RopeDictionary.ContainsKey(rope))
            return;

        BaseNode otherEdge = rope.GetOtherNode(this);
        Vector2 direction = otherEdge.transform.position - this.transform.forward;
        direction = direction.normalized;
        RopeDictionary.Add(rope, direction);
        ShowCount();
    }

    private void ShowCount()
    {
        count = RopeDictionary.Count;
    }
    public void RemoveRope(BaseRope rope)
    {
        RopeDictionary.Remove(rope);
    }

}
