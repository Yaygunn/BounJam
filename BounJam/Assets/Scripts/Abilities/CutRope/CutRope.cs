using System.Collections;
using UnityEngine;

public class CutRope : MonoBehaviour, I_Ability
{
    private RopeCutable _currentRope;

    private bool Cutable;

    private void OnDestroy()
    {
        EventHub.E_AbilityChange -= StopAbility;
    }
    public void StartAbility()
    {
        StartCoroutine(CutUpdate());
        CursorManager.Instance.ChangeCursorState(E_CursorState.makas);
        EventHub.E_AbilityChange += StopAbility;
    }

    public void StopAbility()
    {
        EventHub.E_AbilityChange -= StopAbility;
        StopAllCoroutines();
        _currentRope = null;
        Cutable = false;
    }
    public void UseAbility()
    {
        if(_currentRope == null || !Cutable)
        {
            return;
        }

        Cut();
        
    }

    IEnumerator CutUpdate()
    {
        while (true)
        {
            RopeCutable rope = MouseDetection.Instance.IsRopeUnderMouse();
            if(rope != _currentRope)
            {
                FotgetPrevious();
                StartNewRope(rope);
            }
            yield return null;
        }
    }

    private void Cut()
    {
        _currentRope.Cut();
        AbilityManager.Instance.JustCut();
    }
    private void FotgetPrevious()
    {
        if (_currentRope == null)
            return;
        _currentRope.ColorStandart();
        _currentRope = null;
        Cutable = false;
    }
    private void StartNewRope(RopeCutable rope)
    {
        if(rope == null)
            return;

        _currentRope = rope;
        Cutable = _currentRope.IsCutable();
        if(Cutable)
        {
            _currentRope.ColorCut();
        }
        else
        {
            _currentRope.ColorUnCutable();
        }
    }
}
