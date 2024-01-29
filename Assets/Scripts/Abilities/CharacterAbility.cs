using UnityEngine;

public abstract class CharacterAbility : MonoBehaviour
{
    protected AbilityInfo _abilityInfo;
    protected Character _character;
    protected Enemy _enemy;
    protected float _elapsedTime;

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

        _character.LooseMana(_abilityInfo.ManaCost);
        _elapsedTime = 0;
    }
    /// <summary>
    /// Check cooldown and manacost
    /// </summary>
    public virtual bool CanUse()
    {
        var elapsed = _elapsedTime >= _abilityInfo.Cooldown;
        var manaEnough = _character.CurrentMana >= _abilityInfo.ManaCost;

        return elapsed && manaEnough; 
    }
    public virtual bool CanGainLevel()
    {
        return _abilityInfo.MaxLevel > UserData.GetAbilityLevel(_abilityInfo.CodeName);
    }
    public virtual void GainLevel()
    {
        if (!CanGainLevel()) return;

        UserData.IncrementAbilityLevel(_abilityInfo.CodeName);
    }
}