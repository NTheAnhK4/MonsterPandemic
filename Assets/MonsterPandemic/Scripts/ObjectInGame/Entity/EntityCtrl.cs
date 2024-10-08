

using System;
using UnityEngine;

public abstract class EntityCtrl : ComponentBehavior
{
    [SerializeField] protected int entityId;
   
    [SerializeField] protected ScriptableObject data;
    [SerializeField] protected int level;
    protected float timeDespawn;

    public ScriptableObject Data => data;

    public int EntityId => entityId;

    public int Level => level;
    

    protected ActionMachine actionMachine;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.ResetEntityId();
        
        this.ResetLevel();
        this.LoadData();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetTimeDespawn();
    }

    protected abstract void ResetEntityId();
    

    protected abstract void LoadData();

    protected virtual void ResetLevel()
    {
        this.level = 1;
    }

    public virtual void ResetLevel(int newLevel)
    {
        this.level = newLevel;
    }
    protected virtual void ResetTimeDespawn()
    {
        
    }
    protected virtual void OnEnable()
    {
        actionMachine = new ActionMachine();
        
    }

    protected virtual void Update()
    {
        actionMachine.Update();
    }


    public virtual void SetPrepareAction()
    {
        
    }
    public abstract void SetInitialAction();
    public abstract void SetEnemyDetectedAction(DamageReceiver damageReceiver);
    public virtual void SetDespawn()
    {
        
    }

}
