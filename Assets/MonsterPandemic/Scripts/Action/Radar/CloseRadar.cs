

using UnityEngine;

public class CloseRadar : Radar
{
  
    protected override void ScanRadar()
    {
        Vector2 posFire = new Vector2(transform.position.x - 0.05f, transform.position.y);
        hit = Physics2D.Raycast(posFire, Vector2.right, 0.25f, layer);
        
        
        
    }
}
