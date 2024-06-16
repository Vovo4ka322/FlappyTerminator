using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //public event Action<Player> Triggered;

    public override void Die()
    {
        base.Die();
        //Triggered?.Invoke(this);
    }
}
