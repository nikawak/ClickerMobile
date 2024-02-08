using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CritIncreaceAbility : CharacterAbility
{
    [SerializeField] private float _time = 15f;

    public override void Use()
    {
        if (!CanUse()) return;
        base.Use();

        _character.SetWeaponCrit(CalculateCrit(), _time);
    }
    public float CalculateCrit()
    {
        var abilityLevel = UserData.GetAbilityLevel(AbilityInfo.CodeName);
        var multiplier = 20;
        var crit = abilityLevel * multiplier;

        return crit;
    }
}
