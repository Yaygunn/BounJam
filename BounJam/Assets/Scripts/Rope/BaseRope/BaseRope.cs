using System;
using UnityEngine;

public class BaseRope : MonoBehaviour 
{
    [field:SerializeField] public bool Walkable {  get; private set; }

    [field: SerializeField] private BaseNode[] nodes = new BaseNode[2];

    public event Action E_RopeCut;

    private void Start()
    {
        if (nodes[0] != null && nodes[1] != null)
            RopeStart();
    }
    public virtual void RopeStart()
    {
        SetTransformAccordingToNodes();
        SendDataToNodes();
    }
    public void InitiateRope(BaseNode n1, BaseNode n2)
    {
        nodes[0] = n1;
        nodes[1] = n2;
        RopeStart();
    }
    public BaseNode[] GetNodes()
    {
        return nodes;
    }

    public BaseNode GetOtherNode(BaseNode node)
    {
        if (nodes[0] == node)
            return nodes[1];
        else
            return nodes[0];
    }
    
    private void SendDataToNodes()
    {
        nodes[0].AddRope(this);
        nodes[1].AddRope(this);
    }

    private void SetTransformAccordingToNodes()
    {
        //Set Position According to nodes;
    }
}
