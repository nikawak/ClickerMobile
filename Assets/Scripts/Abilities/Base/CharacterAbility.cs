using System.Numerics;
using UnityEngine;

public abstract class CharacterAbility : MonoBehaviour
{
    [SerializeField] protected EnemyController _enemyController;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Character _character;
    [SerializeField] protected AudioClip _audioHit;

    public AbilityInfo AbilityInfo;

    protected float _elapsedTime;
    protected Calculator _calculator;
    protected virtual void Start()
    {
        _calculator = new Calculator();
    }
    protected virtual void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime;
    }
    /// <summary>
    /// check if can use ability, then loose character mana and reset timer
    /// </summary>
    public virtual void Use()
    {
        if (!CanUse()) return;

        _character.LooseMana(AbilityInfo.ManaCost);
        _elapsedTime = 0;
    }
    /// <summary>
    /// Check cooldown and manacost
    /// </summary>
    public virtual bool CanUse()
    {
        var elapsed = _elapsedTime >= AbilityInfo.Cooldown;
        var manaEnough = _character.CurrentMana >= AbilityInfo.ManaCost;

        return elapsed && manaEnough; 
    }
    public virtual bool CanGainLevel()
    {
        var price = CalculateLevelPrice() < UserData.Coins;
        var level = AbilityInfo.MaxLevel > UserData.GetAbilityLevel(AbilityInfo.CodeName);
        return level && price;
    }
    public virtual void GainLevel()
    {
        if (!CanGainLevel()) return;

        UserData.IncrementAbilityLevel(AbilityInfo.CodeName);
    }
    public virtual BigInteger CalculateLevelPrice()
    {
        var level = UserData.GetAbilityLevel(AbilityInfo.CodeName);
        var price = _calculator.CalculateLevelAbilityPrice(level, AbilityInfo.StartPrice);
        return price;
    }
}