using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunTurretCtrl : WeaponCtrl
{
    protected override void ResetEntityId()
    {
        this.entityId = 0;
    }

    protected override void ResetEntityType()
    {
        this.entityType = "RangedWeapon";
    }

    protected override void ResetTimeDespawn()
    {
        timeDespawn = 0;
    }
}
