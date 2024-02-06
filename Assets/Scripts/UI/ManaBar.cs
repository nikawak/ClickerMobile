using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _manaUI;
    [SerializeField] private Character _character;
    [SerializeField] private float _recoveryCooldown;
    
    private float _cooldownTimeElapsed;

    private void Start()
    {
        SetMaxMana();
        SetMana();
        _character.ManaChaged.AddListener(ManaChaged);
    }
    private void Update()
    {
        ManaRecovery();
    }
    private void ManaChaged()
    {
        SetMaxMana();
        SetMana();
    }


    public void SetMaxMana()
    {
        _slider.maxValue = _character.MaxMana;
    }
    public void SetMana()
    {
        var mana = (int)_character.CurrentMana;
        SetManaTextUI(mana);
        _slider.value = mana;
    }
    public void SetManaTextUI(int mana)
    {
        _manaUI.text = mana + " / " + (int)_character.MaxMana;
    }
    public void ManaRecovery()
    {
        _cooldownTimeElapsed += Time.deltaTime;
        var percent = _character.MaxMana / 100;
        if(_cooldownTimeElapsed > _recoveryCooldown)
        {
            _cooldownTimeElapsed = 0;
            _character.RecoverMana(percent);
        }
    }
}
