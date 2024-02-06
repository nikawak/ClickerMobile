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
        _clickableAbility.SetActive(level > 0);
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
