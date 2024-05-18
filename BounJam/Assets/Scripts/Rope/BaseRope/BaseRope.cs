using System;
using UnityEngine;

public class BaseRope : MonoBehaviour 
{
    [field:SerializeField] public bool Walkable {  get; private set; }

    [field: SerializeField] protected BaseNode[] nodes = new BaseNode[2];

    public event Action E_RopeCut;

    [SerializeField] float ScaleMultiplyConstant;

    private void Start()
    {
        if (nodes[0] != null && nodes[1] != null)
            SendDataToNodes();
    }

    public void InitiateRope(BaseNode n1, BaseNode n2)
    {
        nodes[0] = n1;
        nodes[1] = n2;
        SendDataToNodes();
        SetTransformAccordingToNodes() ;
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

    public void SetTransformAccordingToNodes()
    {
        transform.position = nodes[0].transform.position;
        Vector2 direction = nodes[1].transform.position - nodes[0].transform.position;
        transform.up = direction;

        Vector3 scale = transform.localScale;
        scale.y = direction.magnitude * ScaleMultiplyConstant;
        transform.localScale = scale;
    }
}
