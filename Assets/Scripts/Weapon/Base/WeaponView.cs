using System;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private TextMeshProUGUI _description;

    [SerializeField] private Image _icon;
    [SerializeField] private Image _panel;
    [SerializeField] private Color _locked;
    [SerializeField] private Color _unlockedIcon;

    [SerializeField] private Button _btnUse;
    private void Start()
    {
        SetDescription();
        SetLock();
    }
    private void Update()
    {
        SetLock(); //оптимизировать на события
        _btnUse.interactable = !_weapon.IsEquiped;
    }
    public void SetLock()
    {
        if (_weapon.UnclockCondition())
        {
            Unlock();
        }
        else
        {
            Lock();
        }
    }
    public void Use()
    {
        _weapon.Use();
        _btnUse.interactable = false;
    }
    [ContextMenu(nameof(SetDescription))]
    public void SetDescription()
    {
        var text = _weapon.WeaponName +" - ";
        text += "\nШанс крита: " + _weapon.CritChance*100+"%";
        text += "\nУрон крита: " + _weapon.CritMultiplier+"x";
        text += "\nУвеличение урона: " + _weapon.DamageMultiplier +"x";
        _description.text = text;
    }

    [ContextMenu(nameof(Unlock))]
    public void Unlock()
    {
        _icon.color = _unlockedIcon;
        _panel.color = Color.white;
        _btnUse.gameObject.SetActive(true);
    }
    [ContextMenu(nameof(Lock))]
    public void Lock()
    {
        _icon.color = _locked;
        _panel.color = _locked;
        _btnUse.gameObject.SetActive(false);
    }
}