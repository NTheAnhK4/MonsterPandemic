

using UnityEngine;

public abstract class MonsterCtrl : EntityCtrl
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    protected AnimMachine animMachine;
    protected bool isDead;

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }

    public SpriteRenderer SpriteRenderer => spriteRenderer;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadSpriteRenderer();
    }
    protected virtual void LoadSpriteRenderer()
    {
        if (spriteRenderer != null) return;
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        if(spriteRenderer != null)
            Debug.Log(transform.name + " Load SpriteRenderer successful");
    }

    

    protected virtual void LoadAnimator()
    {
        if(animator != null) return;
        animator = transform.GetComponentInChildren<Animator>();
        if(animator != null)
            Debug.Log(transform.name + " Load Animator successful");
    }

    

    protected override void OnEnable()
    {
       
        base.OnEnable();
        animMachine = new AnimMachine();
        isDead = false;
        SetInitialAction();
       
    }

    public override void SetInitialAction()
    {
        animMachine.ChangeAnim(new BasicMoveAnim(animator));
        
        
        if(data is RangedMonsterData ranged)
            actionMachine.ChangeAction(MovementFactory.CreateMovement(
                ranged.Data[entityId].moveType,
                transform,
                ranged.Data[entityId].GetSpeed(level),
                Vector3.left
            ));
        if(data is ToughMonsterData tough)
            actionMachine.ChangeAction(MovementFactory.CreateMovement(
                tough.Data[entityId].moveType,
                transform,
                tough.Data[entityId].GetSpeed(level),
                Vector3.left
            ));
    }

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        animMachine.ChangeAnim(new BasicAttackAnim(animator));
        
       
    }


    public override void SetDespawn()
    {
        animMachine.ChangeAnim(new BasicDeadAnim(animator));
        
    }

   
    protected override void Update()
    {
        base.Update();
        if(isDead) SetDespawn();
    }
}
