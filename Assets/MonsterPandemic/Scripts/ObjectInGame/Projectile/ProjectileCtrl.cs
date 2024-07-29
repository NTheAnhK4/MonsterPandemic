using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileCtrl : EntityCtrl
{
    
   
   
    protected override void ResetEntityType()
    {
        this.entityType = "Projectile";
    }

    protected override void LoadData()
    {
        if (data != null) return;
        string resPath = "Projectile/ProjectileData";
        data = Resources.Load<ProjectileData>(resPath);
        if(data != null) Debug.Log(transform.name + " Load Data successful");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SetMovement();
    }

    public virtual void SetMovement()
    {
        if (data is not ProjectileData projectileData)
        {
            Debug.LogError("Error to load projectile data");
            return;
        }
        actionMachine.ChangeAction(MovementFactory.CreateMovement(
            projectileData.Data[entityId].moveType,
            transform,
            projectileData.Data[entityId].GetSpeed(level),
            Vector3.right
            ));
    }

    public virtual void SetAttack(DamageReceiver damageReceiver)
    {
        if (data is not ProjectileData projectileData)
        {
            Debug.LogError("Error to load projectile data");
            return;
        }
        actionMachine.ChangeAction(AttackFactory.CreateMeleeAttack(
            projectileData.Data[entityId].range,
            0,
            projectileData.Data[entityId].GetDamage(level),
            damageReceiver
            ));
    }
}
