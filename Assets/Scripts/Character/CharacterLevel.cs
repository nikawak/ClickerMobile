using JetBrains.Annotations;
using Newtonsoft.Json.Bson;
using System;
using System.Diagnostics;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLevel : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;
    private Calculator _calculator;
    
    private void Start()
    {
        UserData.LevelCharacter = 100;
        _level.text = UserData.LevelCharacter.ToString();
        _calculator = new Calculator();
    }
    private void Update()
    {
        _btn.interactable = CanGainLevel(out var price);
        _price.text = DigitConverter.ConvertToText(price).text;
    }

    public BigInteger CalculatePrice()
    {
        var level = UserData.LevelCharacter;
        var stage = UserData.StageCharacter;

        var price = _calculator.CurrentValue;

        price = _calculator.CalculateLevelPrice(level, stage);
        
        return price;
    }
   
    public void GainLevel()
    {
        if (!CanGainLevel(out var price)) return;
        BuyLevel(price);
    }

    private bool CanGainLevel(out BigInteger price)
    {
        price = CalculatePrice();
        return UserData.Coins > price;
    }
    private void BuyLevel(BigInteger price)
    {
        UserData.Coins -= price;
        UserData.LevelCharacter++;
        UserData.StageCharacter = UserData.LevelCharacter / 10;
        _level.text = UserData.LevelCharacter.ToString();
    }

}
