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

    public int CurrentMana => _currentMana;
    private int ManaCapacity => _manaCapacity;
    private void Start()
    {
        UserData.LevelCharacter = 1;
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
        var additionMultiplier = level / 5;
        additionMultiplier = additionMultiplier == 0 ? 2 : additionMultiplier + 1;

        var damage = BigInteger.Pow(level, additionMultiplier) * additionMultiplier * ((int)_weapon.DamageMultiplier * 100)/100;
        
        var rand = new System.Random();
        damage = rand.NextDouble() > (double)_weapon.CritChance ? damage * 2 : damage;
        return damage;
    }
    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
    public void GainLevel() => UserData.LevelCharacter += 1; 
    
}
