
using UnityEngine;

public class Ctrl : ComponentBehavior
{
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.A))
      {
         
         ProjectileSpawner.Instance.SpawnRandomObject(Vector3.zero);
      }
   }
}
