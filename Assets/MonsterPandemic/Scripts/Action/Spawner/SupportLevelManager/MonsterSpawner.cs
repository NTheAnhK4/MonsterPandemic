
using System.Collections;
using UnityEngine;

public class MonsterSpawner : ComponentBehavior
{
    protected int totalMonsters;
    protected int curMonster;
    protected float timeSpawn = 2;
    protected override void Awake()
    {
        totalMonsters = Random.Range(1, 17);
        curMonster = 0;
        this.AddListener(EventID.On_Finish_Wave, param => DestroyWave());
        StartCoroutine(SpawnMonster());
    }

    protected IEnumerator SpawnMonster()
    {
        while (curMonster < 4)
        {
            yield return new WaitForSeconds(timeSpawn);
            if (((1 << curMonster) & totalMonsters) != 0)
            {
                MonsterCtrl monsterCtrl = VanguardMonsterSpawner.Instance.SpawnRandomObject(transform.position).GetComponent<MonsterCtrl>();
                monsterCtrl.SpriteRenderer.sortingOrder = 5 - (int)((transform.position.y + 3) / 1.5f);
                this.PostEvent(EventID.On_Spawn_Monster,1);
            }
                
            UpdateValue();
            
        }
    }

    protected virtual void UpdateValue()
    {
        curMonster++;
        timeSpawn = Random.Range(2, 3);
    }

    protected virtual void DestroyWave()
    {
        //WaveSpawner.Instance.DespawnObject(transform);
    }
}
