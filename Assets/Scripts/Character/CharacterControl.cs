using System;
using System.Numerics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Character _character;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _audioHit;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextMeshProUGUI _damageText;
    private void Start()
    {
        _character = GetComponent<Character>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Tap();
    }
    public void Tap()
    {
        _character.DealDamage();
        _animator.SetTrigger("Hit");
        _audioSource.PlayOneShot(_audioHit);
            
        CreateText(_character.CalculateDamage());
        
    }
    private void CreateText(BigInteger num)
    {
        var rand = new System.Random();
        
        var tmpro = Instantiate(_damageText, _canvas.transform);
        tmpro.text = DigitConverter.ConvertToText(num).text;
        tmpro.transform.position += new UnityEngine.Vector3(Convert.ToSingle(rand.NextDouble()*500) - 250f, Convert.ToSingle(rand.NextDouble()*500) - 250f, 0);
        Destroy(tmpro.gameObject, 0.3f);
    }
}