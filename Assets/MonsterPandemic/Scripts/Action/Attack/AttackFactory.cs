

using UnityEngine;

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

    public static Attack CreateRangedAttack(Range range,float attackSpeed, string bulletName, Vector3 pos, int level)
    {
        Attack attack = null;
        switch (range)
        {
            case Range.WholeLaneToTheRight:
                attack = new WholeRightLaneAttack(attackSpeed, bulletName,pos, level);
                break;
        }
        
        return attack;
    }
}
