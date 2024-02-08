using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected float _damageMultiplier;
    [SerializeField] protected float _critChance;
    [SerializeField] protected float _critMultiplier;

    //[SerializeField] protected Transform _parent;
    [SerializeField] protected Character _character;
    [SerializeField] protected bool _isEquiped;

    public float DamageMultiplier => _damageMultiplier;
    public float CritChance => _critChance;
    public float CritMultiplier => _critMultiplier;
    public string WeaponName => _name;
    public bool IsEquiped => _isEquiped;


    public virtual void Equipe()
    {
        _isEquiped = true;
        _character.SetWeapon(this);//связь лишняя
    }
    public virtual void Unequipe()
    {
        _isEquiped = false;
    }
    public float CalculateCrit()
    {
        var rand = new System.Random().NextDouble();
        var needCrit = _critChance > rand;
        var crit = needCrit ? _critMultiplier : 1;
        return crit;
    }
    public IEnumerator SetCrit(float crit, float time)
    {
        var tempCrit = _critChance;
        _critChance = crit;
        yield return new WaitForSeconds(time);
        _critChance = tempCrit;
    }
    public abstract bool UnclockCondition(); //оптимизировать на события
}