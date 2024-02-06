using System;
using TMPro;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathPaticle;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Enemy _enemy;
    
    private void Start()
    {
        _enemy.OnDeath.AddListener(OnDeath);
    }

    private void OnDeath()
    {
        _deathPaticle.Play();
        _audioSource.PlayOneShot(_deathSound);
    }
}