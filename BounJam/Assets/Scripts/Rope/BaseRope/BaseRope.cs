using System;
using UnityEngine;

public class BaseRope : MonoBehaviour 
{
    [field:SerializeField] public bool Walkable {  get; private set; }

    [field: SerializeField] protected BaseNode[] nodes = new BaseNode[2];

    [SerializeField] protected SpriteRenderer spriteRenderer;

    [SerializeField] protected GameObject colliderObject;

    public event Action E_RopeCut;

    [SerializeField] float ScaleMultiplyConstant;
    [SerializeField] float ColliderScaleMultiplyConstant;

    private bool HasAddedToNode;

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
        if (HasAddedToNode)
            return;
        HasAddedToNode = true;
        print("SendData");
        nodes[0].AddRope(this);
        nodes[1].AddRope(this);
    }

    public void SetTransformAccordingToNodes()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);

        transform.position = (nodes[0].transform.position + nodes[1].transform.position) * 0.5f;
        Vector2 direction = nodes[1].transform.position - nodes[0].transform.position;
        transform.up = direction;


        //Vector2 v = spriteRenderer.size;
        //= direction.magnitude * ScaleMultiplyConstant;
        spriteRenderer.size = new Vector2( direction.magnitude * ScaleMultiplyConstant , 3);

        Vector3 scale = colliderObject.transform.localScale;
        scale.y = direction.magnitude * ColliderScaleMultiplyConstant;
        colliderObject.transform.localScale = scale;
    }
}
