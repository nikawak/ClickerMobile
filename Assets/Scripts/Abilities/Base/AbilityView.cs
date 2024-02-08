using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System;
using System.Diagnostics;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private CharacterAbility _characterAbility;
    [SerializeField] private GameObject _clickableAbility;
    [SerializeField] private Image _clickableMask;

    private void Start()
    {
        var level = UserData.GetAbilityLevel(_characterAbility.AbilityInfo.CodeName);
        _level.text = level.ToString();
    }
    private void Update()
    {
        _btn.interactable = CanGainLevel();
        _price.text = DigitConverter.ConvertToText(CalculatePrice()).text;


        var level = UserData.GetAbilityLevel(_characterAbility.AbilityInfo.CodeName);
        _level.text = level.ToString();
        _clickableAbility.SetActive(level > 0);

        var elapsed = _characterAbility.Elapsed;
        var cd = _characterAbility.AbilityInfo.Cooldown;
        var fillAmount = 1 - elapsed / cd;
        _clickableMask.fillAmount = fillAmount < 0 ? 0 : fillAmount;
    }

    public BigInteger CalculatePrice()
    {
        return _characterAbility.CalculateLevelPrice();
    }

    private bool CanGainLevel()
    {
        return _characterAbility.CanGainLevel();
    }

}
