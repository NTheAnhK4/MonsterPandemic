


using UnityEngine;

public class MonsterParam : EntityParam
{
    public float maxHp;
    public float hpGrowthRate;
    
    public SpeedRate speedRate;
    public float speedGrowthRate;

    
    
    public float GetMaxHp(int objectLevel)
    {
        return maxHp + (objectLevel - level) * hpGrowthRate;
    }

    public float GetSpeed(int objectLevel)
    {
        float speed = (objectLevel - level) * speedGrowthRate;
        switch (speedRate)
        {
            case SpeedRate.Creeper:
                return speed + 0.2f;
            case SpeedRate.Stiff:
                return speed + 0.22f;
            case SpeedRate.Basic:
                return speed + 0.3f;
            case SpeedRate.Hungry:
                return speed + 0.4f;
            case SpeedRate.Speedy:
                return speed + 0.59f;
            case SpeedRate.Flightly:
                return speed + 2.93f;
        }

        return speed;
    }

    
}
