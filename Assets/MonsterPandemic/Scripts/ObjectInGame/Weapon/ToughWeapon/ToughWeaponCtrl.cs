using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToughWeaponCtrl : WeaponCtrl
{
    protected override void LoadData()
    {
        if (data != null) return;
        string resPath = "Weapon/ToughWeaponData";
        data = Resources.Load<ToughWeaponData>(resPath);
        if(data != null) Debug.Log(transform.name + " Load Data successful");
    }

    public override void SetInitialAction()
    {
        base.SetInitialAction();
    }

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        base.SetEnemyDetectedAction(damageReceiver);
    }

    public override void SetDespawn()
    {
        base.SetDespawn();
        actionMachine.ChangeAction(new WeaponDespawner(transform,timeDespawn,"ToughWeapon"));
        
    }
}
