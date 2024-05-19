using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowKill : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void OnEnable()
    {
        if(KillCounter.Instance != null)
        {
            text.text = KillCounter.Instance.GetEnemyCount().ToString();
        }

    }
}
