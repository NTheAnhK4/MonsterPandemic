
using System.Collections.Generic;

using UnityEngine;

public class Spawner : ComponentBehavior
{
    
    [SerializeField] protected Transform holders;
    [SerializeField] protected List<Transform> prefabList;
    [SerializeField] protected List<Transform> poolObject;

    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabList();
        this.LoadHolders();
    }

    protected virtual void LoadPrefabList()
    {
        if (prefabList.Count != 0) return;
        Transform prefabs = transform.Find("Prefabs");
        foreach (Transform prefab in prefabs)
        {
            prefabList.Add(prefab);
        }

        this.HidePrefab();
    }

    protected virtual void HidePrefab()
    {
        foreach (var VARIABLE in prefabList)
        {
            VARIABLE.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHolders()
    {
        if (this.holders != null) return;
        Transform transform1;
        this.holders = (transform1 = transform).Find("Holders");
        Debug.Log(transform1.name + " Load holders successful");
    }

    protected virtual Transform GetObjectByName(string objectName)
    {
        foreach (var obj in prefabList)
        {
            if (obj.name == objectName) return obj;
        }

        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (var obj in poolObject)
        {
            if (obj.name == prefab.name)
            {
                poolObject.Remove(obj);
                return obj;
            }
        }

        Transform newprefab = Instantiate(prefab);
        newprefab.name = prefab.name;
        return newprefab;
    }
    public virtual Transform Spawn(string prefabName, Vector3 position)
    {
        Transform prefab = GetObjectByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError("Donnot have object with name in prefab" +  prefabName);
            return null;
        }

        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetParent(holders);
        newPrefab.SetPositionAndRotation(position,newPrefab.rotation);
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    public virtual Transform Spawn(string prefabName, Vector3 position, Quaternion rot)
    {
        Transform newPrefab = Spawn(prefabName, position);
        newPrefab.SetPositionAndRotation(position, rot);
        return newPrefab;
    }

    public virtual Transform Spawn(string prefabName, Vector3 position, Transform parent)
    {
        Transform newPrefab = Spawn(prefabName, position);
        newPrefab.SetParent(parent);
        return newPrefab;
    }

    public virtual Transform Spawn(string prefabName, Vector3 position, Quaternion rot, Transform parent)
    {
        Transform newPrefab = Spawn(prefabName, position, rot);
        newPrefab.SetParent(parent);
        return newPrefab;
    }

    public virtual Transform SpawnRandomObject(Vector3 position)
    {
        int pos = Random.Range(0, prefabList.Count);
        Transform newPrefab = GetObjectFromPool(prefabList[pos]);
        newPrefab.SetParent(holders);
        newPrefab.SetPositionAndRotation(position,newPrefab.rotation);
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }
   
    public virtual void DespawnObject(Transform obj)
    {
        obj.gameObject.SetActive(false);
        poolObject.Add(obj);
    }
}
