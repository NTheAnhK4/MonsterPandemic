
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

    protected bool IsDead()
    {
        if (ctrl is ProjectileCtrl) return false;
        if (ctrl is WeaponCtrl weaponCtrl) return weaponCtrl.IsDead;
        if (ctrl is MonsterCtrl monsterCtrl) return monsterCtrl.IsDead;
        return true;
    }
    protected virtual void SetEnemyDetectedAction()
    {
        if (!IsEnemy() || IsDead()) return;
        ctrl.SetEnemyDetectedAction(hit.transform.GetComponent<DamageReceiver>());
    }
    protected virtual void SetInitialAction()
    {
        if (hit.collider != null || ctrl is ProjectileCtrl || IsDead()) return;
        ctrl.SetInitialAction();
    }
    protected void Update()
    {
        ScanRadar();
        SetEnemyDetectedAction();
        SetInitialAction();
    }
}
