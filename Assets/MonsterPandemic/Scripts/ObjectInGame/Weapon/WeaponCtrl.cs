
using UnityEngine;

public abstract class WeaponCtrl : EntityCtrl
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected DamageReceiver damageReceiver;
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
        this.LoadDamageReceiver();
    }
    protected virtual void LoadAnimator()
    {
        if(animator != null) return;
        animator = transform.GetComponentInChildren<Animator>();
        if(animator != null)
            Debug.Log(transform.name + " Load Animator successful");
    }

    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        if(damageReceiver != null)
            Debug.Log(transform.name + " Load DamageReceiver successful");
    }
    public override void SetInitialAction()
    {
        animMachine.ChangeAnim(new IdleAnim(animator));
        actionMachine.ChangeAction(new IdleAction());
    }

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        animMachine.ChangeAnim(new BasicAttackAnim(animator));
    }

    public override void SetDespawn()
    {
        animMachine.ChangeAnim(new BasicDeadAnim(animator));
    }

    protected override void OnEnable()
    {
       
        base.OnEnable();
        animMachine = new AnimMachine();
        isDead = false;
        SetInitialAction();
       
    }
    protected override void Update()
    {
        base.Update();
        if(isDead) SetDespawn();
    }

}
