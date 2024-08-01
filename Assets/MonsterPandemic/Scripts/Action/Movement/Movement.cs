using UnityEngine;

public class Movement : IAction
{
    protected Transform _obj;
    protected float _speed;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public Movement(Transform obj, float speed)
    {
        _obj = obj;
        _speed = speed;
    }
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void UpdatePhysis()
    {
      
    }

    public virtual void UpdateLogic()
    {
       
    }
}
