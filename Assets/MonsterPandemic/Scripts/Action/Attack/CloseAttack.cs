

public class CloseAttack : Attack
{
    protected float _damage;
    protected DamageReceiver _damageReceiver;
    public CloseAttack(float attackSpeed, float damage, DamageReceiver damageReceiver) : base(attackSpeed)
    {
        _damage = damage;
        _damageReceiver = damageReceiver;
    }

    protected override void OnAttack()
    {
        if (_damageReceiver == null) return;
        _damageReceiver.Deduct(_damage);
    }
}
