using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AbilityManager.Instance.GetResource();
            AudioManager.Instance.GetResource();
            Destroy(gameObject);
        }
    }
}
