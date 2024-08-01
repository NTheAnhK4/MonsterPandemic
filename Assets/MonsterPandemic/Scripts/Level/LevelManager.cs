
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelManager : ComponentBehavior
{
    [SerializeField] protected float timeSpawn = 1f;
    [SerializeField] protected float timer = 0f;
    
    protected int minWave = 6;
    protected int maxWave = 12;
    [SerializeField] protected int totalWaves;
    [SerializeField] protected int curWave;
    protected override void Awake()
    {
        totalWaves = Random.Range(minWave, maxWave);
        curWave = 0;
        timer = 0f;
        this.AddListener(EventID.On_Finish_Wave, param => SpawnWave());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeSpawn) SpawnWave();
    }

    protected virtual void SpawnWave()
   {
       if (curWave >= totalWaves)
       {
           Debug.Log("You Win");
           return;
       }
       curWave++;
       timer = 0f;
       timeSpawn = 20 + 60.0f / curWave;
       this.PostEvent(EventID.On_Random_Spawn_Next_Wave,curWave);
   }
   
}
