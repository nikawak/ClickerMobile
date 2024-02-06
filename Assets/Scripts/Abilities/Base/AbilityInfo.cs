using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityInfo", menuName = "Gameplay/New ability information")]
public class AbilityInfo : ScriptableObject
{
    [SerializeField] private long _startPrice;
    public long StartPrice => _startPrice;
    [SerializeField] private string _codeName;
    public string CodeName => _codeName;
    [SerializeField] private int _maxLevel;
    public int MaxLevel => _maxLevel;
    [SerializeField] private int _manaCost;
    public int ManaCost => _manaCost;
    [SerializeField] private float _cooldown;
    public float Cooldown => _cooldown;
}