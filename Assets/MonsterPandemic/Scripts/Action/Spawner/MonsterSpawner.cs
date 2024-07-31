
using System.Collections;
using UnityEngine;

public class MonsterSpawner : ComponentBehavior
{
    protected int totalMonsters;
    protected int curMonster;
    protected float timeSpawn = 2;
    protected override void Awake()
    {
        totalMonsters = Random.Range(1, 33);
        curMonster = 0;
        StartCoroutine(SpawnMonster());
    }

    protected IEnumerator SpawnMonster()
    {
        while (curMonster < 5)
        {
            yield return new WaitForSeconds(timeSpawn);
            if(((1 << curMonster) & totalMonsters) != 0)
                VanguardMonsterSpawner.Instance.SpawnRandomObject(transform.position);
            UpdateValue();
            
        }
    }

    protected virtual void UpdateValue()
    {
        curMonster++;
        timeSpawn = Random.Range(2, 3);
    }
}
