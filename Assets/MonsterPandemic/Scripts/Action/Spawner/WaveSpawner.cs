
using UnityEngine;


public class WaveSpawner : Spawner
{
    private static WaveSpawner instance;

    public static WaveSpawner Instance => instance;
    [SerializeField] protected float maxHorizontal = 21;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 WaveSpawner allow to exist");
        instance = this;
        Init();
        this.AddListener(EventID.On_Random_Spawn_Next_Wave, param => SpawnNextWave());
    }

    protected virtual void Init()
    {
        maxHorizontal = 21;
    }

    protected virtual void SpawnNextWave()
    {
        int type = Random.Range(1, 33);
       
        for (int i = 0; i < 5; ++i)
        {
            if (((1 << i) & type) != 0)
            {
                SpawnRandomObject(new Vector3(maxHorizontal, 1.5f * i - 3, 0));
            }
        }
    }
    
}
