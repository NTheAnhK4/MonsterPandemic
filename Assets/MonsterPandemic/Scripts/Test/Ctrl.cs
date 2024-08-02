
using System;
using UnityEngine;

public class Ctrl : ComponentBehavior
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug .Log("Ee");
   }
}
