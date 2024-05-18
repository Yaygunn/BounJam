using System;
using UnityEngine;

[field:SerializeReference]
public interface I_Ability 
{

    public void StartAbility();

    public void StopAbility();

    public void UseAbility();
}
