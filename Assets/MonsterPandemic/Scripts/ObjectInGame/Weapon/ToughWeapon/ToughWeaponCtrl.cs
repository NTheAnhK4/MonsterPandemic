using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToughWeaponCtrl : WeaponCtrl
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpriteRenderer();
    }

    protected virtual void LoadSpriteRenderer()
    {
        if (spriteRenderer != null) return;
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        if(spriteRenderer != null)
            Debug.Log(transform.name + " Load SpriteRenderer successful");
    }

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
        if (data is not ToughWeaponData toughWeaponData)
        {
            Debug.LogError("Load data error");
            return;
        }

        actionMachine.ChangeAction(new DefenseAction(damageReceiver, spriteRenderer, toughWeaponData.Data[entityId].HurtSprites));
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
