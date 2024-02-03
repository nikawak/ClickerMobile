using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
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
    public void Shoot()
    {
        var xForce = (Random.value - 0.5f) * 2;
        var zForce = (Random.value - 0.5f) * 2;
        var yForce = Random.value * 5;
        var vecForce = new UnityEngine.Vector3(xForce, yForce, zForce);
        _rb = _rb ?? GetComponent<Rigidbody>();
        _rb.AddForce(vecForce, ForceMode.Impulse);
    }
}