
using UnityEngine;

public class ProjectileDespawner : Despawner
{
   
    public ProjectileDespawner(Transform obj, float timeDespawn) : base(obj, timeDespawn)
    {
    }
    protected override void OnDespawn()
    {
       ProjectileSpawner.Instance.DespawnObject(_obj);
    }
}
