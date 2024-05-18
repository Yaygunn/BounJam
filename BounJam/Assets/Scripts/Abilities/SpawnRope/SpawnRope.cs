using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRope : MonoBehaviour, I_Ability
{
    [SerializeField] private RopeCutable prefabRope;
    private Node _currentNode;

    [SerializeField] private Node _playerNode;

    private void Awake()
    {
        EventHub.E_PlayerNode += GetNodePlayerIsOn;
    }

    private void GetNodePlayerIsOn(Node node)
    {
        _playerNode = node;
    }
    public void StartAbility()
    {
        EventHub.E_AbilityChange += StopAbility;
        StartCoroutine(RopeAbility());
    }

    public void StopAbility()
    {
        EventHub.E_AbilityChange -= StopAbility;
        StopAllCoroutines();
    }
    public void UseAbility()
    {
        
        Node node = MouseDetection.Instance.IsNodeUnderMouse();
        if(node == null)
        {
            return;
        }

        foreach(BaseNode Anode in node.GetAllOtherNodes())
        {
            if(_playerNode == Anode)
            {
                print("fail");
                return;
            }
        }
        RopeCutable rope = Instantiate(prefabRope);
        rope.InitiateRope(_playerNode, node);
    }

    IEnumerator RopeAbility()
    {
        while (true)
        {
            Node node = MouseDetection.Instance.IsNodeUnderMouse();

            if (node == _currentNode)
            {

            }
            else
            {
                ForgetPreviousNode();
                SetNewNode(node);
            }           

            yield return null;
        }
    }
    private void SetNewNode(Node node)
    {
        if (node == null)
        {
            return;
        }

        _currentNode = node;
        // open view change
    }

    private void ForgetPreviousNode()
    {
        if (_currentNode == null)
            return;

        //close view change
        _currentNode = null;
    }
}

