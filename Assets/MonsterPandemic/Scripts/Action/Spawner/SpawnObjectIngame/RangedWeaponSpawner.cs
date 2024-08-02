using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponSpawner : Spawner
{
    private static RangedWeaponSpawner instance;

    public static RangedWeaponSpawner Instance => instance;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 RangedWeaponSpawner allow to exist");
        instance = this;
    }
}
