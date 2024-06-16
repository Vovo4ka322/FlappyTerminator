using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{
    private void Update()
    {
        Fire();
    }

    public override void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            base.Fire();
    }
}
