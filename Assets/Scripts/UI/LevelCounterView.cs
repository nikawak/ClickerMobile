using System;
using TMPro;
using UnityEngine;

public class LevelCounterView : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void Start()
    {
        _enemyController.OnEnemyDeath.AddListener(LevelChanged);
    }
    private void LevelChanged()
    {
        _levelText.text = "Level " + UserData.Level;
    }
}