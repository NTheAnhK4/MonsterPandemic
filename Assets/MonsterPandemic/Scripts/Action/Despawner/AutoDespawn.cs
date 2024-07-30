

using System;
using UnityEngine;

public abstract class AutoDespawn : ComponentBehavior
{
    [SerializeField] protected EntityCtrl ctrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (ctrl != null) return;
        ctrl = transform.parent.GetComponent<EntityCtrl>();
        if(ctrl != null)
        {
            var transform1 = transform;
            Debug.Log(transform1.parent.name + " " + transform1.name + " Load Ctrl successful");
        }
    }

    private void Update()
    {
        UpdateLogic();
        if (!CanDespawn()) return;
        DespawnObject();
    }

    protected virtual void UpdateLogic()
    {
        
    }
    protected abstract bool CanDespawn();

    protected void DespawnObject()
    {
        ctrl.SetDespawn();
    }
}
