
using UnityEngine;

public class Attack : IAction
{
    protected float _attackSpeed;
    protected float coolDown;
    protected int attackCount;
    public Attack(float attackSpeed)
    {
        _attackSpeed = attackSpeed;
    }
    public virtual void Enter()
    {
        attackCount = 0;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void UpdatePhysis()
    {
        if (coolDown < _attackSpeed) return;
        OnAttack();
        attackCount++;
        coolDown = 0;
    }

    public virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    protected virtual void OnAttack()
    {
        
    }

    public int GetAttackCount()
    {
        return attackCount;
    }
}
