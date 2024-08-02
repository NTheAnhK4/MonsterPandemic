using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBoxCtrl : ToughWeaponCtrl
{
    protected override void ResetEntityId()
    {
        this.entityId = 0;
    }

    protected override void ResetTimeDespawn()
    {
        this.timeDespawn = 0;
    }
}
