using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _currentEnemy;
    public Enemy CurrentEnemy => _currentEnemy;
    public GameObject[] StageEnemies;
    public GameObject Boss;
    public Vector3 SpawnPoint;
    public int EnemiesToBoss;

    private void Start()
    {
        UserData.Level = 0;
        _currentEnemy = StageEnemies[UserData.Level].GetComponent<Enemy>();
        SpawnEnemy();
    }
    public void SpawnIteration()
    {
        RemoveEnemy();
        SpawnEnemy();
        UserData.Level++;
        UserData.Level = UserData.Level >= StageEnemies.Length ? 0 : UserData.Level;
    }
    public Enemy SpawnEnemy()
    {
        var level = UserData.Level;
        GameObject nextEnemy;

        if (level % EnemiesToBoss == 0)
            nextEnemy = Instantiate(Boss, SpawnPoint, Quaternion.AngleAxis(180,Vector3.up));
        else
            nextEnemy = Instantiate(StageEnemies[level], SpawnPoint, Quaternion.AngleAxis(180, Vector3.up));
        _currentEnemy = nextEnemy.GetComponent<Enemy>();
        _currentEnemy.OnDeath.AddListener(SpawnIteration);

        return _currentEnemy;
    }
    public void RemoveEnemy()
    {
        _currentEnemy.OnDeath.RemoveAllListeners();
        Destroy(_currentEnemy.gameObject);
    }
}
