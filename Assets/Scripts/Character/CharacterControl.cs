using System;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Character _character;
    private Animator _animator;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextMeshProUGUI _damageText;
    private void Start()
    {
        _character = GetComponent<Character>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Tap();
    }
    private void Tap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character.DealDamage();
            _animator.SetTrigger("Hit");
            CreateText("-"+_character.CalculateDamage().ToString());
        }
    }
    private void CreateText(string text)
    {
        var rand = new System.Random();
        
        var tmpro = Instantiate(_damageText, _canvas.transform);
        tmpro.text = text;
        //tmpro.transform.SetParent(_canvas.transform);
        tmpro.transform.position += new Vector3(Convert.ToSingle(rand.NextDouble()*500) - 250f, Convert.ToSingle(rand.NextDouble()*500) - 250f, 0);
        Destroy(tmpro.gameObject, 0.3f);
    }
}