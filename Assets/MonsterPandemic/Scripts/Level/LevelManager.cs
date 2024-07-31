
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelManager : ComponentBehavior
{
    [SerializeField] protected float timeSpawn = 1f;
    
    protected int minWave = 6;
    protected int maxWave = 12;
    [SerializeField] protected int totalWaves;
    [SerializeField] protected int curWave;
    protected override void Awake()
    {
        totalWaves = Random.Range(minWave, maxWave);
        curWave = 0;
    }

    protected override void Start()
    {
        StartCoroutine(SpawnWave());
    }

    protected IEnumerator SpawnWave()
    {
        while (curWave <= totalWaves)
        {
            yield return new WaitForSeconds(timeSpawn);
            curWave++;
            timeSpawn = Math.Min(timeSpawn + 5, 15);
            this.PostEvent(EventID.On_Random_Spawn_Next_Wave,curWave);
        }
    }
   
}
