using System.Numerics;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private BigInteger _value;
    [SerializeField] private TextMeshProUGUI _valueText;
    private void Start()
    {
        Destroy(gameObject, 2);
    }
    private void OnDestroy()
    {
        UserData.Coins += _value;
    }
    public void SetValue(BigInteger value)
    {
        _value = value;
        _valueText.text = value.ToString();
    }
    
}