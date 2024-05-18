using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour, I_Ability
{
    [SerializeField] private Node prefabNode;

    private Node _playerNode;

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
        CursorManager.Instance.ChangeCursorState(E_CursorState.node);
        StartCoroutine(NodeAbility());
    }

    public void StopAbility()
    {
        EventHub.E_AbilityChange -= StopAbility;
        StopAllCoroutines();
    }
    public void UseAbility()
    {
        SpawnNodeOnMousePoint();
    }

    private void SpawnNodeOnMousePoint()
    {
        Vector2 mousePos = MouseDetection.Instance.GetMousePosition();
        Node node = Instantiate(prefabNode,mousePos,Quaternion.identity);
    }
    IEnumerator NodeAbility()
    {
        while (true)
        {
            Node node = MouseDetection.Instance.IsNodeUnderMouse();

            if (node != null)
            {
                WrongPlace();
            }
            else
            {
                CorrectPlace();
            }
          
            yield return null;
        }
    }


    private void WrongPlace()
    {
        //change view
    }

    private void CorrectPlace()
    {
        //Change View
    }
    
}
