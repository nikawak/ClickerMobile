using System;
using TMPro;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathPaticle;
    [SerializeField] private ParticleSystem _bloodParticle;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Enemy _enemy;
    
    private void Start()
    {
        _enemy.OnDeath.AddListener(OnDeath);
        _enemy.OnDeepWounds.AddListener(OnDeepWounds);
    }

    private void OnDeepWounds()
    {
        if (_bloodParticle.isPlaying) return;
        _bloodParticle?.Play();
    }

    private void OnDeath()
    {
        _deathPaticle?.Play();
        _audioSource?.PlayOneShot(_deathSound);
    }
}