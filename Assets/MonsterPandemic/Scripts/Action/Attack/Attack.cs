
using UnityEngine;

public class Attack : IAction
{
    protected float _attackSpeed;
    protected float coolDown;
    public Attack(float attackSpeed)
    {
        _attackSpeed = attackSpeed;
    }
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void UpdatePhysis()
    {
        if (coolDown < _attackSpeed) return;
        OnAttack();
        coolDown = 0;
    }

    public virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    protected virtual void OnAttack()
    {
        
    }
}
