
using UnityEngine;

public abstract class WeaponCtrl : EntityCtrl
{
    [SerializeField] protected Animator animator;
    
    protected AnimMachine animMachine;
    protected bool isDead;
    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
    }

    protected override void LoadData()
    {
        if(data != null) return;
        string resPath = "Weapon/";
        switch (entityType)
        {
            case "VanguardWeapon":
                resPath += "VanguardWeaponData";
                break;
            case "RangedWeapon":
                resPath += "RangedWeaponData";
                break;
            case "ToughWeapon":
                resPath += "ToughtWeaponData";
                break;
                
        }

        data = Resources.Load<ScriptableObject>(resPath);
        if(data != null)
            Debug.Log(transform.name + " Load Data successful");
    }
    
    protected virtual void LoadAnimator()
    {
        if(animator != null) return;
        animator = transform.GetComponentInChildren<Animator>();
        if(animator != null)
            Debug.Log(transform.name + " Load Animator successful");
    }

    public override void SetInitialAction()
    {
        animMachine.ChangeAnim(new IdleAnim(animator));
        actionMachine.ChangeAction(new IdleAction());
    }

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        animMachine.ChangeAnim(new BasicAttackAnim(animator));
      
        if (data is RangedWeaponData rangedWeaponData)
        {
            actionMachine.ChangeAction(AttackFactory.CreateRangedAttack(
                rangedWeaponData.Data[entityId].range,
                rangedWeaponData.Data[entityId].GetAttackSpeed(level),
                rangedWeaponData.Data[entityId].projectileName,
                transform
            ));
           
        }
           
       
    }

    public override void SetDespawn()
    {
        animMachine.ChangeAnim(new BasicDeadAnim(animator));
        actionMachine.ChangeAction(new WeaponDespawner(transform,timeDespawn,entityType));
    }

    protected override void OnEnable()
    {
       
        base.OnEnable();
        animMachine = new AnimMachine();
        isDead = false;
        SetInitialAction();
       
    }

}
