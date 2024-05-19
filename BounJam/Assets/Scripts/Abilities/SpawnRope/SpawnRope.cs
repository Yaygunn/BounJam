using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRope : MonoBehaviour, I_Ability
{
    [SerializeField] private RopeCutable prefabRope;
    private Node _currentNode;

    [SerializeField] private Node _playerNode;

    [SerializeField] private RopeCursor ropeCursor;

    [SerializeField] private Transform RopeParent;

    private void Awake()
    {
        EventHub.E_PlayerNode += GetNodePlayerIsOn;
    }
    private void OnDestroy()
    {
        EventHub.E_AbilityChange -= this.StopAbility;
    }

    private void GetNodePlayerIsOn(Node node)
    {
        _playerNode = node;
    }
    public void StartAbility()
    {
        EventHub.E_AbilityChange += this.StopAbility;
        CursorManager.Instance.ChangeCursorState(E_CursorState.rope);
        StartCoroutine(RopeAbility());
    }

    public void StopAbility()
    {
        EventHub.E_AbilityChange -= this.StopAbility;
        StopAllCoroutines();
    }
    public void UseAbility()
    {
        
        Node node = MouseDetection.Instance.IsNodeUnderMouse();

        if(node == null|| Movement.Instance.currentNode == null)
        {
            AudioManager.Instance.FailSound();
            return;
        }
        
        foreach(BaseNode Anode in node.GetAllOtherNodes())
        {
            if(_playerNode == Anode)
            {
                AudioManager.Instance.FailSound();
                return;
            }
        }
        RopeCutable rope = Instantiate(prefabRope);
        rope.InitiateRope(Movement.Instance.currentNode, node);
        rope.transform.SetParent(RopeParent);
        AudioManager.Instance.Success();
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

        AudioManager.Instance.HoverOn();
        _currentNode = node;

        foreach (BaseNode Anode in node.GetAllOtherNodes())
        {
            if (_playerNode == Anode)
            {
                ropeCursor.FailColor();
                return;
            }
        }

        ropeCursor.CorrectColor();

    }

    private void ForgetPreviousNode()
    {
        if (_currentNode == null)
            return;

        _currentNode = null;
        AudioManager.Instance.Hoverof();

        ropeCursor.StardartColor();
    }
}

