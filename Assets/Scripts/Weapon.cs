using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _critChance;
    [SerializeField] private Vector3 _weaponToUserPoint;
    [SerializeField] private Quaternion _weaponToUserAngle;
    [SerializeField] private Character _character;

    public float DamageMultiplier => _damageMultiplier;
    public float CritChance => _critChance;

    public void Use()
    {
        var weapon = Instantiate(this, _weaponToUserPoint, _weaponToUserAngle);
        _character.SetWeapon(weapon);
    }
}