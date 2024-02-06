using System;
using System.Numerics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    public void Tap()
    {
        if (!_character.CanDealDamage) return;
        _character.DealDamage();
    }
}