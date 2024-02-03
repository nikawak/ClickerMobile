using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int _coinsCountAfterDeath;
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private ObjectPool<Coin> _pool;

    [SerializeField] private List<Transform> _points;

    private Calculator _calculator;
    private void Start()
    {
        UserData.Coins = 0;
        _pool = new ObjectPool<Coin>(_coinPrefab, transform, _coinsCountAfterDeath, true);
        _enemyController.OnEnemyDeath.AddListener(SpawnCoins);
        _calculator = new Calculator();
    }

    private void SpawnCoins()
    {
        var reward = CalculateReward();
        for(int i = 0; i < _coinsCountAfterDeath; i++)
        {
            var coin = _pool.GetFreeItem();
            coin.SetValue(reward/_coinsCountAfterDeath);
            coin.DisableCoin(1.5f);
            //coin.Shoot();
            var index = new System.Random().Next(_points.Count-1);
            coin.transform.position = _points[index].position;
        }
    }
    public BigInteger CalculateReward()
    {
        var level = UserData.Level;
        var stage = UserData.Stage;

        var value = _calculator.CalculateReward(level, stage);

        return value;
    }
    
}
