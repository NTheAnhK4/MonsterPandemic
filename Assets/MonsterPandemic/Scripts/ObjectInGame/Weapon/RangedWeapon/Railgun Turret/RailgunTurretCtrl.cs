using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunTurretCtrl : RangedWeaponCtrl
{
    protected override void ResetEntityId()
    {
        this.entityId = 0;
    }
    

    protected override void ResetTimeDespawn()
    {
        timeDespawn = 0;
    }

    protected override void ResetLevel()
    {
        this.level = 1;
    }
}
