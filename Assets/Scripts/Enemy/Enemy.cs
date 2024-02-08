using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyVFX))]
public class Enemy : MonoBehaviour
{
    private BigInteger _health;
    private Animator _animator;
    private Calculator _calculator = new Calculator();

    public UnityEvent OnDeath;
    public UnityEvent<BigInteger> OnGetDamage;
    public UnityEvent OnDeepWounds;
    public HealthBar _healthBar;
    public float _timeToDie = 1f;
    private bool isDead;
    public BigInteger Health => _health;
    private void Start()
    {
        _calculator = new Calculator();
        _animator = GetComponent<Animator>();

        SetStartHealth();
    }

    private void OnEnable()
    {
        SetStartHealth();
    }
    private void OnDisable()
    {
        OnGetDamage.RemoveAllListeners();
    }
    public void SetStartHealth()
    {
        _health = CalculateHealth();
        _healthBar.SetMaxHealth(_health);
        _healthBar.SetHealth(_health);
    }
    public BigInteger CalculateHealth()
    {
        var level = UserData.Level;
        var stage = UserData.Stage;
        _calculator = _calculator ?? new Calculator();
        var value = _calculator.CalculateHP(level, stage);

        return value;
    }
    public virtual void GetDamage(BigInteger damage)
    {
        if (isDead) return;

        _health -= damage;
        _health = _health > 0 ? _health : 0;
        _healthBar.SetHealth(_health);

        if(_health == 0)
        {
            Die(_timeToDie);
        }
        else
        {
            OnGetDamage.Invoke(damage);
            _animator.SetTrigger("Hit");
        }

    }
    public void DeepWoundsApply(BigInteger damage, int applyTimes)
    {
        StartCoroutine(DeepWoundsApplyAsync(damage, applyTimes));
    }
    private IEnumerator DeepWoundsApplyAsync(BigInteger damage, int applyTimes)
    {
        OnDeepWounds.Invoke();
        for (int i = 0; i < applyTimes; i++) 
        {
            yield return new WaitForSeconds(0.3f);

            _health -= damage;
            _health = _health > 0 ? _health : 0;
            _healthBar.SetHealth(_health);

            if (_health == 0)
            {
                Die(_timeToDie);
            }
            
        }
    }
    public void Die(float time)
    {
        StartCoroutine(DieAsync(time));
    }
    private IEnumerator DieAsync(float time)
    {
        isDead = true;
        _animator.SetTrigger("Die");
        
        yield return new WaitForSeconds(time);

        
        gameObject.SetActive(false);
        isDead = false;
        OnDeath?.Invoke();
    }
    public void MakeBoss()
    {
        var bossMultiplier = 8;
        _health = CalculateHealth() * bossMultiplier;
        transform.localScale *= 1.4f;

        _healthBar.SetMaxHealth(_health);
        _healthBar.SetHealth(_health);
        OnDeath.AddListener(OnBossDead);
    }

    private void OnBossDead()
    {
        OnDeath.RemoveListener(OnBossDead);
        UserData.Stage++;
        transform.localScale /= 1.4f;
    }
}
