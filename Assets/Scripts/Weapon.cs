using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _critChance;
    [SerializeField] private Transform _parent;
    [SerializeField] private Character _character;

    public float DamageMultiplier => _damageMultiplier;
    public float CritChance => _critChance;

    public void Use()
    {
        var weapon = Instantiate(this, _parent);
        _character.SetWeapon(weapon);
    }
}