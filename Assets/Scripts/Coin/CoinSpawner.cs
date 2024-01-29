using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int _coinsCountAfterDeath;
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private ObjectPool<Coin> _pool;
    private void Awake()
    {
        _enemyController.CurrentEnemy.OnDeath.AddListener(SpawnCoins);
        _pool = new ObjectPool<Coin>(_coinPrefab, transform, 30);
    }

    private void SpawnCoins()
    {
        _enemyController.CurrentEnemy.OnDeath.RemoveAllListeners();
        var reward = CalculateReward();
        
        for(int i = 0; i < _coinsCountAfterDeath; i++)
        {
            var coin = _pool.GetFreeItem();
            coin.SetValue(reward/_coinsCountAfterDeath);
        }
    }
    public BigInteger CalculateReward()
    {
        var level = UserData.Level;
        var additionMultiplier = level / 3;
        additionMultiplier = additionMultiplier == 0 ? 2 : additionMultiplier + 1;

        var reward = BigInteger.Pow(level, additionMultiplier) + 8;

        return reward;
    }
    
}
