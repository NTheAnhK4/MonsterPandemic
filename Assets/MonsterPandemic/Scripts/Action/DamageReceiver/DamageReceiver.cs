
using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class DamageReceiver : ComponentBehavior
{
    [SerializeField] protected EntityCtrl ctrl;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
        this.LoadRigidbody();
        this.LoadCollider();
    }
    protected virtual void LoadCtrl()
    {
        if (ctrl != null) return;
        ctrl = transform.parent.GetComponent<EntityCtrl>();
        if(ctrl != null) Debug.Log(transform.name + " Load Ctrl successful");
    }
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = transform.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            ChangeRigidInfor();
            var transform1 = transform;
            Debug.Log(transform1.parent.name + " " + transform1.name + " Load Rigid successful");
        }
            
    }

    protected virtual void ChangeRigidInfor()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0;
    }
    protected virtual void LoadCollider()
    {
        if (boxCollider2D != null) return;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        if (boxCollider2D != null)
        {
            ChangeColliderInfor();
            var transform1 = transform;
            Debug.Log(transform1.parent.name + " " + transform1.name + " Load Collider successful" );
        }
    }

    protected virtual void ChangeColliderInfor()
    {
        boxCollider2D.isTrigger = true;
        boxCollider2D.offset = new Vector2(0, 0f);
        boxCollider2D.size = new Vector2(0.25f, 0.5f);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetMaxHp();
    }

    protected virtual void ResetMaxHp()
    {
        if(ctrl is MonsterCtrl) ResetMonsterMaxHp();
        else ResetWeaponMaxHp();
        curHp = maxHp;
    }

    protected virtual void ResetMonsterMaxHp()
    {
       
        maxHp = ctrl.Data switch
        {
            VanguardMonsterData vanguard => vanguard.Data[ctrl.EntityId].GetMaxHp(ctrl.Level),
            RangedMonsterData ranged => ranged.Data[ctrl.EntityId].GetMaxHp(ctrl.Level),
            ToughMonsterData tough => tough.Data[ctrl.EntityId].GetMaxHp(ctrl.Level),
            _ => 1 
        };
    }

    protected virtual void ResetWeaponMaxHp()
    {
        maxHp = ctrl.Data switch
        {
            VanguardWeaponData vanguard => vanguard.Data[ctrl.EntityId].GetMaxHp(ctrl.Level),
            RangedWeaponData ranged => ranged.Data[ctrl.EntityId].GetMaxHp(ctrl.Level),
            ToughWeaponData tough => tough.Data[ctrl.EntityId].GetMaxHp(ctrl.Level),
            _ => 1
        };
    }

    public void Deduct(float damage)
    {
        curHp -= damage;
        
    }
}
