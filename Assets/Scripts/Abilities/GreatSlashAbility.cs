using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GreatSlashAbility : CharacterAbility
{
    public BigInteger Damage => CalculateDamage();
    private void Start()
    {
    }
    public override void Use()
    {
        base.Use();

        
    }
    public BigInteger CalculateDamage()
    {
        var abilityLevel = UserData.GetAbilityLevel(_abilityInfo.CodeName);
        var characterDamage = _character.CalculateDamage();
        var multiplier = 5;

        var damage = characterDamage * abilityLevel * multiplier;

        return damage;
    }
}
