using System;
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
            spawner.EnemyDestroyed += IncreaseValue;
        }
    }

    private void OnDisable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.EnemyDestroyed -= IncreaseValue;
        }
    }

    public void IncreaseValue(int amount)
    {
        _value += amount;
        Changed?.Invoke(_value);
    }
}
