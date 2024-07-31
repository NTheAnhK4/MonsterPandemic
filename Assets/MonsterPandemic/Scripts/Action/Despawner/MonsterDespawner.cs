
using UnityEngine;

public class MonsterDespawner : Despawner
{

    protected string _monsterType;
    public MonsterDespawner(Transform obj, float timeDespawn,string monsterType) : base(obj, timeDespawn)
    {
        _monsterType = monsterType;
    }

    protected override void OnDespawn()
    {
       
        switch (_monsterType)
        {
            case "VanguardMonster":
                VanguardMonsterSpawner.Instance.DespawnObject(_obj);
                return;
        }
    }
}
