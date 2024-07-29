


using UnityEngine;

public class MonsterParam : EntityParam
{
    public float maxHp;
    public float hpGrowthRate;
    
    public SpeedRate speedRate;
    public float speedGrowthRate;
    public MoveType moveType;
    
    
    public float GetMaxHp(int objectLevel)
    {
        return maxHp + (objectLevel - level) * hpGrowthRate;
    }

    public float GetSpeed(int objectLevel)
    {
        float speed = (objectLevel - level) * speedGrowthRate;
        switch (speedRate)
        {
            case SpeedRate.TurtleSpeed:
                return speed + 0.2f;
            case SpeedRate.SlowPace:
                return speed + 0.22f;
            case SpeedRate.ModerateSpeed:
                return speed + 0.3f;
            case SpeedRate.SwiftRate:
                return speed + 0.4f;
            case SpeedRate.RapidVelocity:
                return speed + 0.59f;
            case SpeedRate.TurboBoost:
                return speed + 2.93f;
            case SpeedRate.AgileFlow:
                return speed + 10f;
            case SpeedRate.LightningSprint:
                return speed + 50f;
        }

        return speed;
    }

    
}
