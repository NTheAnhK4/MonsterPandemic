using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughWeaponSpawner : Spawner
{
    private static ToughWeaponSpawner instance;

    public static ToughWeaponSpawner Instance => instance;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 Tough Weapon Spawner allow to exist");
        instance = this;
    }
}
