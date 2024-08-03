using System;

using UnityEngine;

public class ItemManager : ComponentBehavior
{
    private static ItemManager instance;

    public static ItemManager Instance => instance;
    [SerializeField] private ClickableObject selectedObject;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only one item manager allow to exist");
        instance = this;
    }
    public void SetSelectedObject(ClickableObject obj)
    {
        
        selectedObject = obj;
    }

   

    public void CreateNewObject(Vector3 pos, Transform parent)
    {
        if (selectedObject == null) return;
        SpawnRandomWeaponItem.Instance.CurNumItem--;
        switch (selectedObject.EntityType)
        {
            case "RangedWeapon":
                RangedWeaponSpawner.Instance.Spawn(selectedObject.EntityName, pos,parent);
                break;
        }
        selectedObject.DestroyObject();
        selectedObject = null;
    }
}
