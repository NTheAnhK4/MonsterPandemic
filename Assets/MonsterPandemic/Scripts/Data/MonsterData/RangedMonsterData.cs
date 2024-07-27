using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RangedMonsterData", menuName = "Data/MonsterData/RangedMonsterData")]
public class RangedMonsterData : ScriptableObject
{
    public List<RangedMonsterParam> Data;
}

[Serializable]
public class RangedMonsterParam : MonsterParam
{
    public string projectileName;
    public float attackSpeed;
    public float attackSpeedGrowthRate;

    public float GetAttackSpeed(int objectLevel)
    {
        return (objectLevel - level) * attackSpeedGrowthRate + attackSpeed;
    }
}
