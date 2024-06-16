using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : Character
{
    [SerializeField] private int _amount;

    public event Action<Enemy> Triggered;
    public event Action<int> Died;

    public override void Die()
    {
        Triggered?.Invoke(this);
    }   

    public void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.TryGetComponent(out Player player))
            player.Die();

      if(collision.TryGetComponent(out PlayerBullet playerBullet))
        {
            Died?.Invoke(_amount);
        }
    }
}
