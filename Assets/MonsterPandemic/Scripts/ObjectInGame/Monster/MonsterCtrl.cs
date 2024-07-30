
using UnityEngine;

public abstract class MonsterCtrl : EntityCtrl
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
        string resPath = "Monster/";
        switch (entityType)
        {
            case "VanguardMonster":
                resPath += "VanguardMonsterData";
                break;
            case "RangedMonster":
                resPath += "RangedMonsterData";
                break;
            case "ToughMonster":
                resPath += "ToughtMonsterData";
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

    

    protected override void OnEnable()
    {
       
        base.OnEnable();
        isDead = false;
        animMachine = new AnimMachine();
       
    }

    public override void SetInitialAction()
    {
        animMachine.ChangeAnim(new BasicMoveAnim(animator));
        if (data is VanguardMonsterData vanguard)
            actionMachine.ChangeAction(MovementFactory.CreateMovement(
                vanguard.Data[entityId].moveType,
                transform,
                vanguard.Data[entityId].GetSpeed(level),
                Vector3.left
            ));
        
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

   
    public override void SetDespawn()
    {
        animMachine.ChangeAnim(new BasicDeadAnim(animator));
        
        actionMachine.ChangeAction(new MonsterDespawner(
            transform,
            timeDespawn,
            entityType
            ));
        isDead = false;
    }

    protected override void Update()
    {
        base.Update();
        
        if(isDead) SetDespawn();
    }
}
