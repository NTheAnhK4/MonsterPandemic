
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ToughMonsterData", menuName = "Data/MonsterData/ToughMonsterData")]
public class ToughMonsterData : ScriptableObject
{
    public List<ToughMonsterParam> Data;
}
[Serializable]
public class ToughMonsterParam : MonsterParam
{
    public float armor;
    public float armorGrowthRate;

    public float GetArmor(int objectLevel)
    {
        return (objectLevel - level) * armorGrowthRate + armor;
    }
}
