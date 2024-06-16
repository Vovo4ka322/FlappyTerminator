using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _spawners;

    private int _value;

    public event Action<int> Changed;

    private void OnEnable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.EnemySpawned += OnEnemySpawned;
            spawner.EnemyDestroyed += OnEnemyDestroyed;
        }
    }

    private void OnDisable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.EnemySpawned -= OnEnemySpawned;
            spawner.EnemyDestroyed -= OnEnemyDestroyed;
        }
    }

    public void IncreaseValue(int amount)
    {
        _value += amount;
        Changed?.Invoke(_value);
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Died += IncreaseValue;
    }

    private void OnEnemyDestroyed(Enemy enemy)
    {
        enemy.Died -= IncreaseValue;
    }
}
