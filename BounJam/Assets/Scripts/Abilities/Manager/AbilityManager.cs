using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] SpawnNode A_SpawnNode;
    [SerializeField] SpawnRope A_SpawnRope;
    [SerializeField] CutRope A_CutRope;


    [SerializeField] int NodeRight;
    [SerializeField] int RopeRight;
    [SerializeField] int CutRight;
    I_Ability _currentAbility;

    void Start()
    {
        _currentAbility = A_SpawnNode;
        _currentAbility.StartAbility();

        InputGameplay.Instance.E_LeftClick += UseAbility;
        InputGameplay.Instance.E_RightClick += TryToSwitchAbility;
    }

    private void OnDestroy()
    {
        InputGameplay.Instance.E_LeftClick -= UseAbility;
        InputGameplay.Instance.E_RightClick -= TryToSwitchAbility;
    }

    private void UseAbility()
    {
        _currentAbility.UseAbility();
    }

    private void TryToSwitchAbility()
    {
        if (!IsThereAnyRight())
        {
            return;
        }
    }

    private void StartNextAbility(int i)
    {

    }

    private bool IsThereAnyRight()
    {
        return true;
    }

    private bool IsAbilityHasRight(int index)
    {
        return true;
        if(index == 0)
        {
            if (NodeRight > 0)
            {
                return true;
            }
            return false;
        }
        if(index == 1)
        {
            if(RopeRight > 0)
            {
                return true;
            }
            return false;
        }
        
            if(CutRight > 0)
            {
                return true;
            }
            return false;
        
    }
}
