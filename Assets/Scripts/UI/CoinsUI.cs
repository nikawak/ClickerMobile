using System.Numerics;
using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    private BigInteger _coins;
    private void Update()
    {
        if(UserData.Coins != _coins) //change to events
        {
            _coins = UserData.Coins;
            _coinsText.text = DigitConverter.ConvertToText(_coins).text;
        }
    }
}