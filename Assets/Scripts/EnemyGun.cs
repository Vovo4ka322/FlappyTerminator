using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Gun
{
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    public void ShootByEnemy()
    {
        _coroutine = StartCoroutine(ShotFrequency());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ShotFrequency()
    {
        WaitForSeconds delay = new(_delay);

        while (enabled)
        {
            Fire();

            yield return delay;
        }
    }
}
