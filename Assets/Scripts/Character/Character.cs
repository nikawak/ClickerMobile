using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterControl))]
public class Character : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private float _currentMana;
    [SerializeField] private float _maxMana;
    [SerializeField] private BigInteger _damage;

    private Calculator _calculator;

    public float CurrentMana => _currentMana;
    public float MaxMana => _maxMana;
    public UnityEvent DealingDamage;
    public UnityEvent ManaChaged;
    public bool CanDealDamage;
    //public float AdditionalDamageMultiplier = 1f;
    private void Start()
    {
        _calculator = new Calculator();
        //Screen.SetResolution(500, 900, false);
    }
    public void LooseMana(float amount)
    {
        if (_currentMana == 0) return;
        _currentMana -= amount;
        ManaChaged.Invoke();
    }
    public void RecoverMana(float amount)
    {
        if (_currentMana == _maxMana) return;
        _currentMana += amount;
        _currentMana = _currentMana > _maxMana? _maxMana: _currentMana;
        ManaChaged.Invoke();
    }
    public void IncreaceManaLevel(float newMaxMana)
    {
        _maxMana = newMaxMana;

        ManaChaged.Invoke();
    }
    public void DealDamage()
    {
        if (!CanDealDamage) return;
        DealingDamage.Invoke();

        var enemy = _enemyController.CurrentEnemy;
        enemy.GetDamage(CalculateDamage()); 
    }
    public BigInteger CalculateDamage()
    {
        var level = UserData.LevelCharacter;
        var stage = UserData.StageCharacter;

        var value = _calculator.CalculateDamage(level, stage, _weapon);
        return value;
    }
    public void SetWeapon(Weapon weapon)
    {
        if(_weapon == weapon) return;
        _weapon.gameObject.SetActive(false);
        _weapon = weapon;
        _weapon.gameObject.SetActive(true);
    }
    public void GainLevel()
    {
        UserData.LevelCharacter++;
    }
    
}
