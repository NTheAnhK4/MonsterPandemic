using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeaponCtrl : WeaponCtrl
{
    protected override void LoadData()
    {
        if (data != null) return;
        string resPath ="Weapon/RangedWeaponData";
        data = Resources.Load<RangedWeaponData>(resPath);
        if(data != null) 
            Debug.Log(transform.name + " Load Data successful");
    }

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        if (data is not RangedWeaponData rangedWeaponData)
        {
            Debug.LogError("Data error");
            return;
        }
        base.SetEnemyDetectedAction(damageReceiver);
        var position = transform.position;
        actionMachine.ChangeAction(AttackFactory.CreateRangedAttack(
            rangedWeaponData.Data[entityId].range,
            rangedWeaponData.Data[entityId].GetAttackSpeed(level),
            rangedWeaponData.Data[entityId].projectileName,
            new Vector3(position.x, position.y + 0.5f, position.z),
            level
        ));
    }

    public override void SetDespawn()
    {
        base.SetDespawn();
        actionMachine.ChangeAction(new WeaponDespawner(transform,timeDespawn,"RangedWeapon"));
    }
}
