using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] SpawnNode A_SpawnNode;
    [SerializeField] SpawnRope A_SpawnRope;
    [SerializeField] CutRope A_CutRope;

    I_Ability _currentAbility;

    void Start()
    {
        _currentAbility = A_CutRope;
        _currentAbility.StartAbility();

        InputGameplay.Instance.E_LeftClick += UseAbility;
    }

    private void OnDestroy()
    {
        InputGameplay.Instance.E_LeftClick -= UseAbility;
    }

    private void UseAbility()
    {
        _currentAbility.UseAbility();
    }
    
}
