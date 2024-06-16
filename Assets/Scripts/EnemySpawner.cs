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

    public event Action<Enemy> EnemySpawned;
    public event Action<Enemy> EnemyDestroyed;

    private void Start()
    {
        StartCoroutine(GeneratorEnemies());
    }

    public void Spawn()
    {
        Enemy enemy = _pool.Return();
        enemy.Triggered += OnEnemyTrigger;
        enemy.gameObject.SetActive(true);
        enemy.transform.position = _spawner.transform.position;
        EnemySpawned?.Invoke(enemy);
    }

    public void OnEnemyTrigger(Enemy enemy)
    {
        enemy.Triggered -= OnEnemyTrigger;

        _pool.Release(enemy);

        enemy.gameObject.SetActive(false);
        EnemyDestroyed?.Invoke(enemy);
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
}
