using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanguardMonsterSpawner : Spawner
{
    private static VanguardMonsterSpawner instance;

    public static VanguardMonsterSpawner Instance => instance;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 VanguardMonster Spawner allow to exist");
        instance = this;
    }
}
