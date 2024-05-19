using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Movement movement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Node"))
        {
            if (movement.currentNode == null)
            {
                movement.StartNodeMovement(collision.GetComponent<Node>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Node"))
        {
            movement.TryEmptyNode(collision.GetComponent<Node>());
        }
    }

}
