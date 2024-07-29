

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
        _damageReceiver.Deduct(_damage);
    }
}
