using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private BigInteger _value;

    private Rigidbody _rb;
    [SerializeField] private TextMeshProUGUI _valueText;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        _rb = _rb?? GetComponent<Rigidbody>();
        _rb.velocity = UnityEngine.Vector3.zero;
    }
    private IEnumerator DisableCoinAsync(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        yield return null;
    }
    public void DisableCoin(float time)
    {
        if (!gameObject.activeInHierarchy) return;

        StartCoroutine(DisableCoinAsync(time));
    }
    private void OnDisable()
    {

        UserData.Coins += _value;
    }
    public void SetValue(BigInteger value)
    {
        _value = value;
        _valueText.text = DigitConverter.ConvertToText(value).text;
    }
    public void Shoot() //remake (coins down and up to ui coins)
    {
        
    }
}