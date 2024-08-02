using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomWeaponItem : ComponentBehavior
{
    [SerializeField] protected float timeSpawn = 5f;
    [SerializeField] protected float coolDown = 0f;
    [SerializeField] protected int maxItem = 5;
    [SerializeField] protected int curNumItem = 0;
    protected override void Awake()
    {
        timeSpawn = 5f;
        coolDown = 0f;
        maxItem = 5;
        curNumItem = 0;
    }

    private void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    private void UpdatePhysis()
    {
        if (curNumItem > maxItem || coolDown < timeSpawn) return;
        SpawnNextItem();
        coolDown = 0;
    }
    private void SpawnNextItem()
    {
        WeaponItemSpawner.Instance. SpawnRandomObject();
        curNumItem++;
    }

    private void Update()
    {
        if (curNumItem > maxItem) return;
        UpdateLogic();
        UpdatePhysis();
    }
}
