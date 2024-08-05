
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon Item", menuName = "Data/Item/WeaponItem")]
public class WeaponItemData : ScriptableObject
{
    public List<WeaponItemParam> data;
}

[Serializable]
public class WeaponItemParam : ItemParam
{
    public string entityType;
}
