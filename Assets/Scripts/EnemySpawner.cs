using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private ObjectPoolEnemy _pool;
    [SerializeField] private float _delay;

    public event Action<int> EnemyDestroyed;

    private void Start()
    {
        StartCoroutine(GeneratorEnemies());
    }

    public void Spawn()
    {
        Enemy enemy = _pool.Return();
        enemy.Triggered += OnEnemyTrigger;
        enemy.Died += OnEnemyDestroyed;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = _spawner.transform.position;
        enemy.Init();
    }

    public void OnEnemyTrigger(Enemy enemy)
    {
        enemy.Triggered -= OnEnemyTrigger;
        enemy.Died -= OnEnemyDestroyed;
        _pool.Release(enemy);
        enemy.gameObject.SetActive(false);
    }

    private IEnumerator GeneratorEnemies()
    {
        WaitForSeconds timeToSpawn = new(_delay);

        while (enabled)
        {
            Spawn();

            yield return timeToSpawn;
        }
    }

    private void OnEnemyDestroyed(int amount)
    {
        EnemyDestroyed?.Invoke(amount);
    }
}
