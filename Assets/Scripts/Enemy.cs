using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private int _amount;
    [SerializeField] private EnemyGun _gun;

    public event Action<Enemy> Triggered;
    public event Action<int> Died;

    public override void Die()
    {
        Triggered?.Invoke(this);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBullet playerBullet))
        {
            Died?.Invoke(_amount);
            Die();
        }

        if (collision.TryGetComponent(out Player player))
            player.Die();
    }

    public void Init()
    {
        _gun.ShootByEnemy();
    }
}
