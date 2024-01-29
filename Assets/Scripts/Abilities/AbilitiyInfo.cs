using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityInfo", menuName = "Gameplay/New ability information")]
public class AbilityInfo : ScriptableObject
{
    [SerializeField] private int _id;
    public int Id => _id;
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private string _codeName;
    public string CodeName => _codeName;
    [SerializeField] private int _maxLevel;
    public int MaxLevel => _maxLevel;
    [SerializeField] private Sprite _icon; 
    public Sprite Icon => _icon;
    [SerializeField] private int _manaCost;
    public int ManaCost => _manaCost;
    [SerializeField] private float _cooldown;
    public float Cooldown => _cooldown;
    [SerializeField] private string _description;
    public string Description => _description;
}