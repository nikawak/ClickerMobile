using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _defaultMusic;
    [SerializeField] private AudioClip _bossMusic;
    [SerializeField] private EnemyController _enemyController;
    void Start()
    {
        _enemyController.BossFightStarts.AddListener(BossMusicStart);
        _enemyController.BossFightEnds.AddListener(BossMusicEnd);
    }

    private void BossMusicEnd()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_defaultMusic);
    }

    private void BossMusicStart()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_bossMusic);
    }
}
