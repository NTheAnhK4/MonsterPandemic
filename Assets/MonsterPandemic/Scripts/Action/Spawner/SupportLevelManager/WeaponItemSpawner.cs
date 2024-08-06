
using UnityEngine;

public class WeaponItemSpawner : Spawner
{
    private static WeaponItemSpawner instance;
   
    public static WeaponItemSpawner Instance => instance;
    protected override void Awake()
    {
        if(instance != null)
            Debug.LogError("Only 1 Weapon Item Spanwer allow to exist");
        instance = this;
      
       
    }
    
    protected override void LoadHolders()
    {
        if(holders != null) return;
        holders = Transform.FindObjectOfType<RepeatRollerConveyor>().transform;
        if(holders != null)
            Debug.Log(transform.name + " Load Holders successful");
    }


    public override Transform SpawnRandomObject()
    {
        Transform newprefab = base.SpawnRandomObject();
        var position = holders.position;
        newprefab.SetPositionAndRotation(new Vector3(position.x, -10, position.z),newprefab.rotation);
        
        return newprefab;
    }
}
