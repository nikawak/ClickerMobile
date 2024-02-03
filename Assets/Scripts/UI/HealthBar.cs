using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private BigInteger _maxHealth;
    
    public void SetMaxHealth(BigInteger value)
    {
        _slider.maxValue = 1f;
        _maxHealth = value;
    }
    public void SetHealth(BigInteger health)
    {
        SetHPTextUI(health);

        var len1 = health.ToString().Length;
        var len2 = _maxHealth.ToString().Length;
        var digitDiff = len2 - len1;

        var strVal1 = new string(health.ToString().Take(15 - digitDiff).ToArray());
        var strVal2 = new string(_maxHealth.ToString().Take(15).ToArray());

        try
        {
            var dec1 = float.Parse(strVal1);
            var dec2 = float.Parse(strVal2);

            _slider.value = dec1 / dec2;
        }
        catch
        {
            //Error => small value => set small
            _slider.value = 0.005f;
        }
    }
    public void SetHPTextUI(BigInteger health)
    {
        var tmpro = DigitConverter.ConvertToText(health);
        _healthUI.text = tmpro.text + " / " + _maxHealth;
        _healthUI.color = tmpro.color;
    }
}
