
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ToughWeaponData", menuName = "Data/WeaponData/ToughWeaponData")]
public class ToughWeaponData : ScriptableObject
{
    public List<ToughWeaponParam> Data;
}

[Serializable]
public class ToughWeaponParam : WeaponParam
{
    public float armor;
    public float armorGrowthRate;

    public float GetArmor(int objectLevel)
    {
        return (objectLevel - level) * armorGrowthRate + armor;
    }
}
