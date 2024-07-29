
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Data/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public List<ProjectileParam> Data;
}
[Serializable]
public class ProjectileParam : EntityParam
{
    public Area area;
    public SpeedRate speedRate;
    public float speedGrowthRate;

    public AttackRate attackRate;
    public float damageGrowthRate;
    public MoveType moveType;
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
    public float GetDamage(int objectLevel)
    {
        float attack = (objectLevel - level) * damageGrowthRate;
        switch (attackRate)
        {
            case AttackRate.Fragile:
                return Random.Range(1, 1.35f) + attack;
            case AttackRate.Average:
                return Random.Range(1.36f, 2.7f) + attack;
            case AttackRate.Solid:
                return Random.Range(2.71f, 4.5f) + attack;
            case AttackRate.Protected:
                return Random.Range(4.51f, 6.4f) + attack;
            case AttackRate.Dense:
                return Random.Range(6.41f, 10) + attack;
            case AttackRate.Hardened:
                return Random.Range(10.01f, 17) + attack;
            case AttackRate.Machined:
                return Random.Range(17.01f, 25) + attack;
            case AttackRate.Great:
                return Random.Range(25.01f, 80) + attack;
            case AttackRate.Undying:
                return Random.Range(80.01f, 295) + attack;
            case AttackRate.UltraUndying:
                return Random.Range(295.01f, 1000) + attack;
        }
        return attack;
    }
}
