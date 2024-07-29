
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Radar : ComponentBehavior
{
    [SerializeField] protected EntityCtrl ctrl;
    [SerializeField] protected Rigidbody2D rb;
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

    protected abstract void LoadCollider();
    protected abstract void ChangeColliderInfor();

    protected void OnEnable()
    {
        ChangeColliderInfor();
    }

    protected bool IsEnemy(Transform other)
    {
        if (transform.tag.Contains("Projectile"))
        {
            if (transform.gameObject.CompareTag("Weapon Projectile")) return other.tag.Contains("Monster");
            else return other.tag.Contains("Weapon");
        }

        if (transform.tag.Contains("Monster"))
            return other.tag.Contains("Weapon");
        if (transform.tag.Contains("Weapon")) return other.tag.Contains("Monster");
        return false;
    }
}
