
using System.Collections.Generic;
using UnityEngine;

public abstract class Radar : ComponentBehavior
{
    [SerializeField] protected EntityCtrl ctrl;
    [SerializeField] protected LayerMask layer;
    protected RaycastHit2D hit;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetLayer();
    }

    protected virtual void ResetLayer()
    {
        if(ctrl is MonsterCtrl) layer = 1 << LayerMask.NameToLayer("Ground Weapon");
        if(ctrl is WeaponCtrl) layer = 1 << LayerMask.NameToLayer("Ground Monster");
        if (ctrl is ProjectileCtrl)
        {
            if(ctrl.transform.tag.Contains("Weapon")) layer = 1 << LayerMask.NameToLayer("Ground Monster");
            else layer = 1 << LayerMask.NameToLayer("Ground Weapon");
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
        
    }

    protected virtual void LoadCtrl()
    {
        if (ctrl != null) return;
        ctrl = transform.parent.GetComponent<EntityCtrl>();
        if(ctrl != null) Debug.Log(transform.name + " Load Ctrl successful");
    }

    protected void Update()
    {
        ScanRadar();
       
        if(IsEnemy()) ctrl.SetEnemyDetectedAction(hit.transform.GetComponent<DamageReceiver>());
    }

    protected abstract void ScanRadar();

   

    protected bool IsEnemy()
    {
        if (hit.collider == null) return false;
        if (transform.tag.Contains("Projectile"))
        {
            if (transform.gameObject.CompareTag("Weapon Projectile")) return hit.collider.tag.Contains("Monster");
            else return hit.collider.tag.Contains("Weapon");
        }

        if (transform.tag.Contains("Monster"))
            return hit.collider.tag.Contains("Weapon");
        if (transform.tag.Contains("Weapon")) return hit.collider.tag.Contains("Monster");
        return false;
    }
}
