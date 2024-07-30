using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : Spawner
{
    private static ProjectileSpawner instance;

    public static ProjectileSpawner Instance => instance;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 Projectile Spawner allow to exist");
        instance = this;
    }
}
