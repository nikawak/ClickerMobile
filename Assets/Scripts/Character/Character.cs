using System;
using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(CharacterControl))]
public class Character : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private int _currentMana;
    [SerializeField] private int _manaCapacity;
    [SerializeField] private BigInteger _damage;

    private Calculator _calculator;

    public int CurrentMana => _currentMana;
    private int ManaCapacity => _manaCapacity;
    private void Start()
    {
        _calculator = new Calculator();
    }
    public void LooseMana(int amount)
    {
        _currentMana -= amount;
    }
    public void DealDamage()
    {
        var enemy = _enemyController.CurrentEnemy;
        enemy.GetDamage(CalculateDamage()); //оптимизировать
    }
    public BigInteger CalculateDamage()
    {
        var level = UserData.LevelCharacter;
        var stage = UserData.StageCharacter;

        var value = _calculator.CalculateDamage(level, stage);
        var rand = new System.Random();
        value = rand.NextDouble() > (double)_weapon.CritChance ? value * 2 : value;
        return value;
    }
    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
    public void GainLevel()
    {
        UserData.LevelCharacter++;
    }
    
}
