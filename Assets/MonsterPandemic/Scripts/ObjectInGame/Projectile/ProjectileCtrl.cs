
using UnityEngine;


public abstract class ProjectileCtrl : EntityCtrl
{
    protected override void LoadData()
    {
        if (data != null) return;
        string resPath = "Projectile/ProjectileData";
        data = Resources.Load<ProjectileData>(resPath);
        if(data != null) Debug.Log(transform.name + " Load Data successful");
    }

    public override void ResetLevel(int newLevel)
    {
        base.ResetLevel(newLevel);
        this.SetInitialAction();
    }

    public override void SetInitialAction()
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

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        if (data is not ProjectileData projectileData)
        {
            Debug.LogError("Error to load projectile data");
            return;
        }
        damageReceiver.Deduct(projectileData.Data[entityId].GetDamage(level));
        SetDespawn();
    }

    public override void SetDespawn()
    {
      
        actionMachine.ChangeAction(new ProjectileDespawner(
            transform,
            0
            ));
    }
    
   
    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetInitialAction();
    }

    protected override void Update()
    {
        base.Update();
        
        if(actionMachine.GetAttackCount() > 0) SetDespawn();
    }
}
