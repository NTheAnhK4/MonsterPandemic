using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDespawner : Despawner
{
    protected string _weaponType;
    public WeaponDespawner(Transform obj, float timeDespawn,string weaponType) : base(obj, timeDespawn)
    {
        _weaponType = weaponType;
    }

    protected override void OnDespawn()
    {
       
        switch (_weaponType)
        {
            case "RangedWeapon":
                RangedWeaponSpawner.Instance.DespawnObject(_obj);
                return;
            case "ToughWeapon":
                ToughWeaponSpawner.Instance.DespawnObject(_obj);
                
                return;
        }
    }
}
