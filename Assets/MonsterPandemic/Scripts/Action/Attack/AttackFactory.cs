

public static class AttackFactory 
{
    public static Attack CreateMeleeAttack(Range range, float attackSpeed, float damage, DamageReceiver damageReceiver)
    {
        Attack attack = null;
        switch (range)
        {
            case Range.Close:
                attack = new CloseAttack(attackSpeed, damage,damageReceiver);
                break;
        }

        return attack;
    }
}
