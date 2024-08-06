
using UnityEngine;


public class WaveSpawner : Spawner
{
    private static WaveSpawner instance;
    private int totalMonters;

    public static WaveSpawner Instance => instance;
    [SerializeField] protected float maxHorizontal = 14;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 WaveSpawner allow to exist");
        instance = this;
        Init();
        this.AddListener(EventID.On_Random_Spawn_Next_Wave, param => SpawnNextWave((int)param));
        this.AddListener(EventID.On_Spawn_Monster,param => AddMonsters((int)param));
        this.AddListener(EventID.On_Monster_Killed, param => RemoveMonsters((int)param));
    }
    

    protected virtual void Init()
    {
        maxHorizontal = 14;
        totalMonters = 0;
    }

    protected virtual void SpawnNextWave(int waveId)
    {
        int type = Random.Range(1, 33);
        for (int i = 0; i < 5; ++i)
        {
            if (((1 << i) & type) != 0)
            {
                SpawnRandomObject(new Vector3(maxHorizontal, 1.5f * i - 3, 20));
            }
        }
    }

    protected virtual void AddMonsters(int num)
    {
        totalMonters += num;
    }

    protected virtual void RemoveMonsters(int num)
    {
        totalMonters -= num;
        if (totalMonters <= 3)
        {
            this.PostEvent(EventID.On_Finish_Wave);
        }
    }
    
    
}
