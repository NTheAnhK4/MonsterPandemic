
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelManager : ComponentBehavior
{
    private static LevelManager instance;
    [SerializeField] protected float timeSpawn = 1f;
    [SerializeField] protected float timer = 0f;
    
    protected int minWave = 6;
    protected int maxWave = 12;
    [SerializeField] protected int totalWaves;
    [SerializeField] protected int curWave;

    public static LevelManager Instance => instance;

    public int CurWave => curWave;

    public int TotalWaves => totalWaves;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 level manager allow to exist");
        instance = this;
        totalWaves = Random.Range(minWave, maxWave);
        MonsterJourneyUI.Instance.ResetMaxValue(totalWaves);
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
