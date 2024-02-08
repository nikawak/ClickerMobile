using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GreatSlashAbility : CharacterAbility
{
    public BigInteger Damage => CalculateDamage();

    public override void Use()
    {
        if (!CanUse()) return;
        base.Use();
        
        StartCoroutine(UseAsync());
    }
    private IEnumerator UseAsync()
    {
        _animator.SetTrigger(AbilityInfo.CodeName);
        _animator.applyRootMotion = true;
        _character.CanDealDamage = false;
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length * 1.8f);

        _animator.applyRootMotion = false;
        _character.CanDealDamage = true;
        _enemyController.CurrentEnemy.GetDamage(CalculateDamage());
    }
    public BigInteger CalculateDamage()
    {
        var abilityLevel = UserData.GetAbilityLevel(AbilityInfo.CodeName);
        var characterDamage = _character.CalculateDamage();
        var multiplier = 30;

        var damage = characterDamage * abilityLevel * multiplier;

        return damage;
    }
}
