using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Gun
{
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(ShotFrequency());
    }

    public override void Fire()
    {
        base.Fire();
    }

    private IEnumerator ShotFrequency()
    {
        WaitForSeconds delay = new(_delay);

        while(enabled)
        {
            Fire();

            yield return delay;
        }
    }
}
