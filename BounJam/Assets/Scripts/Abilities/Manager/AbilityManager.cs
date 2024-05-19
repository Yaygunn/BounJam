using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance { get; private set; } 
    [SerializeField] SpawnNode A_SpawnNode;
    [SerializeField] SpawnRope A_SpawnRope;
    [SerializeField] CutRope A_CutRope;

    [SerializeField] int NodeRight;
    [SerializeField] int RopeRight;
    [SerializeField] int CutRight;
    I_Ability _currentAbility;

    private I_Ability[] _abilities; 
    [SerializeField] int indexAbility;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _abilities = new I_Ability[]{ A_SpawnNode, A_SpawnRope,A_CutRope };

        _abilities[indexAbility].StartAbility();

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
        _abilities[indexAbility].UseAbility();
    }

    private void TryToSwitchAbility()
    {
        int beginningIndex = indexAbility;
 
        while(true)
        {
            IncreaseAbilityIndex();
            if (IsAbilityHasRight(indexAbility))
                break;
        }
        if(indexAbility == beginningIndex)
        {
            return;
        }
        
        
        StartNextAbility();
        
        

    }
    
    private void IncreaseAbilityIndex()
    {
        indexAbility++;
        if(indexAbility == 3) 
        {
            indexAbility = 0;
        }
    }

    private void StartNextAbility()
    {
        EventHub.AbilityChange();
        _abilities[indexAbility].StartAbility();
    }

    private bool IsThereAnyRight()
    {
        return true;
    }

    private bool IsAbilityHasRight(int index)
    {
        if(index !=2)
            return true;
        if (CutRight > 0)
            return true;
        return false;
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

    public void JustCut()
    {
        CutRight--;
        if(CutRight == 0)
        {
            _abilities[indexAbility].StopAbility();
            TryToSwitchAbility();
        }
    }

    public void GetResource()
    {
        CutRight++;
    }
}
