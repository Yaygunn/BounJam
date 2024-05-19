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
            else
            {
                if(_currentRope != null)
                {
                    if (Cutable != IsCutable(rope))
                    {
                        Cutable = IsCutable(rope);
                        if (Cutable)
                        {
                            _currentRope.ColorCut();
                        }
                        else
                        {
                            _currentRope.ColorUnCutable();
                        }
                    }
                }          
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
        Cutable = IsCutable(rope);
        if(Cutable)
        {
            _currentRope.ColorCut();
        }
        else
        {
            _currentRope.ColorUnCutable();
        }
    }

    private bool IsCutable(BaseRope rope)
    {
        if(Movement.Instance.currentRope == rope)
            return false;

        /*Node node = Movement.Instance.currentNode;
        if (node != null)
        {
            if (node.GetAllRopes().Contains(rope))
            {
                if(node.GetAllRopes().Count)
            }
        }*/
        return true;
    }
}
