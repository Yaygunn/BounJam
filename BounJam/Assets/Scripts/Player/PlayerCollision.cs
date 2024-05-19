using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                if (movement.currentRope.GetNodes().Contains(collision.GetComponent<Node>()))
                {
                    movement.StartNodeMovement(collision.GetComponent<Node>());
                }
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            if(collision.GetComponent<Enemy>().IsAlive)
                EndGame.Instance.PlayerDeath();
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
