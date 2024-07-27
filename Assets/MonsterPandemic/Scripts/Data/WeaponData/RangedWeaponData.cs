using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RangedWeaponData", menuName = "Data/WeaponData/RangedWeaponData")]
public class RangedWeaponData : ScriptableObject
{
    public List<RangedWeaponParam> Data;
}

[Serializable]
public class RangedWeaponParam : WeaponParam
{
    public string projectileName;
    public float attackSpeed;
    public float attackSpeedGrowthRate;

    public float GetAttackSpeed(int objectLevel)
    {
        return (objectLevel - level) * attackSpeedGrowthRate + attackSpeed;
    }
}

