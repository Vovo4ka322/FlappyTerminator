using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private ObjectPoolBullet _pool;

    private void Shoot()
    {
        Bullet bullet = _pool.Return();

        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = _firePoint.rotation;
        bullet.Triggered += OnBulletTrigger;
        bullet.gameObject.SetActive(true);
    }

    private void OnBulletTrigger(Bullet bullet)
    {
        bullet.Triggered -= OnBulletTrigger;

        _pool.Release(bullet);

        bullet.gameObject.SetActive(false);
    }

    public virtual void Fire()
    {
        Shoot();
    }
}
