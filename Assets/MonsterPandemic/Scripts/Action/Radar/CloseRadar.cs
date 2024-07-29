

using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class CloseRadar : Radar
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    protected override void LoadCollider()
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

    protected override void ChangeColliderInfor()
    {
        boxCollider2D.isTrigger = true;
        boxCollider2D.offset = new Vector2(0, 0f);
        boxCollider2D.size = new Vector2(0.25f, 0.5f);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        DamageReceiver damageReceiver = other.transform.parent.GetComponentInChildren<DamageReceiver>();
        if (IsEnemy(other.transform))
        {
            if(transform.tag.Contains("Projectile")) ((ProjectileCtrl)ctrl).SetAttack(damageReceiver);
        }
            
    }
}
