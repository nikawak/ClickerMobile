using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private Enemy _currentEnemy;
    public Enemy CurrentEnemy => _currentEnemy ?? StageEnemies[UserData.Level];
    public Enemy[] StageEnemies;
    public Enemy Boss;
    public Vector3 SpawnPoint;
    public int EnemiesToBoss = 10;
    public UnityEvent OnEnemyDeath;
    public float TimeToDie = 1f;
    private RandomCreatedObjectPool<Enemy> _pool;
    public SceneManager _cutscene;

    private void Start()
    {
        //UserData.ResetAll();
        _pool = new RandomCreatedObjectPool<Enemy>(StageEnemies.ToList(), transform, StageEnemies.Count(), false);
        //_currentEnemy = _pool.GetFreeItem();
        SpawnEnemy();
    }
    public void SpawnIteration()
    {
        StartCoroutine(SpawnIterationAsync());
    }
    private IEnumerator SpawnIterationAsync()
    {
        yield return new WaitForSeconds(TimeToDie);
        RemoveEnemy();
        SpawnEnemy();
        UserData.Level++;
        yield return null;
    }
    public Enemy SpawnEnemy()
    {
        var level = UserData.Level;

        _currentEnemy = _pool.GetFreeItem();
        if (level % EnemiesToBoss == 0 && level != 0)
        {
            StartCoroutine(_cutscene.LoadBoss(_currentEnemy, () => _currentEnemy.MakeBoss()));
            // 10x hp for boss
        }
      
        _currentEnemy.OnDeath.AddListener(SpawnIteration);

        return _currentEnemy;
    }
    public void RemoveEnemy()
    {
        _currentEnemy.OnDeath.RemoveAllListeners();

        OnEnemyDeath.Invoke();

    }
}
