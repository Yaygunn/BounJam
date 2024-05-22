using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseNode : MonoBehaviour
{
    protected Dictionary<BaseRope, Vector2> RopeDictionary = new Dictionary<BaseRope, Vector2>();
    [SerializeField] int count;

    public List<BaseRope> GetAllRopes()
    {
        return RopeDictionary.Keys.ToList();
    }
    public void AddRope(BaseRope rope, Vector2 direction)
    {
        if (RopeDictionary.ContainsKey(rope))
            return;

        RopeDictionary.Add(rope, direction);
    }

    public BaseNode[] GetAllOtherNodes()
    {
        List<BaseNode> nodes = new List<BaseNode>();
        foreach(BaseRope rope in RopeDictionary.Keys) 
        {
            nodes.Add(rope.GetOtherNode(this));
        }
        return nodes.ToArray();
    }

    public void RemoveRope(BaseRope rope)
    {
        RopeDictionary.Remove(rope);
    }

    public int GetConnectedRopeCount()
    {
        return RopeDictionary.Count;
    }

}
