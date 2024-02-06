using System;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CharacterVFX : MonoBehaviour
{
    [SerializeField] private AudioClip _audioHit;

    [SerializeField] private Transform _canvas;
    [SerializeField] private TextMeshProUGUI _damageText;

    private Character _character;
    private Animator _animator;
    private AudioSource _audioSource;
    private ObjectPool<TextMeshProUGUI> _textDamagePool;

    private void Start()
    {
        _character = GetComponent<Character>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _character.DealingDamage.AddListener(OnDealDamage);
        _textDamagePool = new ObjectPool<TextMeshProUGUI>(_damageText, _canvas, 10, true);
    }

    private void OnDealDamage()
    {
        _animator.SetTrigger("Hit");
        _audioSource.PlayOneShot(_audioHit);

        CreateTextRandomPos(_character.CalculateDamage());
    }

    private void CreateTextRandomPos(BigInteger num)
    {
        var rand = new System.Random();

        var tmpro = _textDamagePool.GetFreeItem();
        tmpro.text = DigitConverter.ConvertToText(num).text;
        tmpro.transform.position += new UnityEngine.Vector3(Convert.ToSingle(rand.NextDouble() * 500) - 250f, Convert.ToSingle(rand.NextDouble() * 500) - 250f, 0);

        StartCoroutine(DisableText(tmpro, 0.3f));
    }
    private IEnumerator DisableText(TextMeshProUGUI text, float time)
    {
        yield return new WaitForSeconds(time);
        text.gameObject.SetActive(false);
    }
}