using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MonsterCtrl : EntityCtrl
{
    [SerializeField] protected Animator animator;
    protected AnimMachine animMachine;
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
        animMachine = new AnimMachine();
        this.SetMovement();
    }

    public void SetMovement()
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

   
}
