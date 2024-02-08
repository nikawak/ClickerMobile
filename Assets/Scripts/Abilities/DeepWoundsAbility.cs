using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DeepWoundsAbility : CharacterAbility
{

    [SerializeField] private int _applyTimes = 3;
    [SerializeField] private float _time = 10f;
    
    private Enemy _enemy;

    public override void Use()
    {
        if (!CanUse()) return;
        base.Use();
        
        StartCoroutine(UseAsync());
    }
    private IEnumerator UseAsync()
    {
        var time = 0f;
        while (time < _time)
        {
            _character.DealingDamage.AddListener(OnDealDamage);
            
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
           
        }
        _character.DealingDamage.RemoveListener(OnDealDamage);
    }
    private void OnDealDamage()
    {
        DeepWoundsApply(_character.CalculateDamage());
    }

    private void DeepWoundsApply(BigInteger damage)
    {
        var enemy = _enemyController.CurrentEnemy;
        enemy.DeepWoundsApply(CalculateDamage(damage), _applyTimes);
    }
    public BigInteger CalculateDamage(BigInteger dealedDamage)
    {
        var abilityLevel = UserData.GetAbilityLevel(AbilityInfo.CodeName);
        var divider = 6;

        var damage = dealedDamage * abilityLevel / divider;

        return damage;
    }
}
