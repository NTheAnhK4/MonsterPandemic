using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VanguardMonsterCtrl : MonsterCtrl
{
    protected override void LoadData()
    {
        if (data != null) return;
        string resPath = "Monster/VanguardMonsterData";
        data = Resources.Load<VanguardMonsterData>(resPath);
        if(data != null)
             Debug.Log(transform.name + " Load Data successful");
    }

    public override void SetPrepareAction()
    {
        base.SetPrepareAction();
        if (data is not VanguardMonsterData vanguard)
        {
            Debug.LogError("Load Data error");
            return;
        }
        actionMachine.ChangeAction(MovementFactory.CreateMovement(
            vanguard.Data[entityId].moveType,
            transform,
           100,
            Vector3.left
        ));
    }

    public override void SetInitialAction()
    {
        base.SetInitialAction();
        if (data is not VanguardMonsterData vanguard)
        {
            Debug.LogError("Load Data error");
            return;
        }
        actionMachine.SetSpeed( vanguard.Data[entityId].GetSpeed(level));
    }

    public override void SetEnemyDetectedAction(DamageReceiver damageReceiver)
    {
        base.SetEnemyDetectedAction(damageReceiver);
        if (data is not VanguardMonsterData vanguardMonsterData)
        {
            Debug.LogError("Load Data error");
            return;
        }
        actionMachine.ChangeAction(AttackFactory.CreateMeleeAttack(
            vanguardMonsterData.Data[entityId].range,
            vanguardMonsterData.Data[entityId].GetAttackSpeed(level),
            vanguardMonsterData.Data[entityId].GetDamage(level),
            damageReceiver
        ));
    }

    public override void SetDespawn()
    {
        base.SetDespawn();
        bool changeDead = actionMachine.ChangeAction(new MonsterDespawner(
            transform,
            timeDespawn,
            "VanguardMonster"
        ));
        if (!changeDead) return;
        this.PostEvent(EventID.On_Monster_Killed,1);
    }
}
