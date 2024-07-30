
using UnityEngine;

public class Despawner : IAction
{
    protected Transform _obj;
    protected float _timeDespawn;
    protected float coolDown = 0;

    public Despawner(Transform obj,float timeDespawn)
    {
        _obj = obj;
        _timeDespawn = timeDespawn;
        coolDown = 0;
    }
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void UpdatePhysis()
    {
        if (coolDown < _timeDespawn) return;
        OnDespawn();
       
    }

    public virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    protected virtual void OnDespawn()
    {
        
    }
}
