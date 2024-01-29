using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private BigInteger _health;
    private Animator _animator;

    public UnityEvent OnDeath;
    public HealthBar _healthBar;
    private void Start()
    {
        _health = CalculateHealth();
        _healthBar.SetMaxHealth(_health);
        _animator = GetComponent<Animator>();
    }
    public BigInteger CalculateHealth()
    {
        var level = UserData.Level;
        var additionMultiplier = level / 3;
        additionMultiplier = additionMultiplier == 0 ? 2 : additionMultiplier + 1;

        var hp = BigInteger.Pow(level, additionMultiplier) + 7;

        return hp;
    }
    public virtual void GetDamage(BigInteger damage)
    {
        _animator.SetTrigger("Hit");

        _health -= damage;
        _health = _health > 0 ? _health : 0;
        _healthBar.SetHealth(_health);

        if(_health == 0) 
            OnDeath?.Invoke();
    }
}
