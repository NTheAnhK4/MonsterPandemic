
using System.Collections.Generic;
using UnityEngine;

public class WholeRightLaneRadar : Radar
{
    [SerializeField] protected float endRange = 8f;
    [SerializeField] protected float range;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetRange();
    }

    protected virtual void ResetRange()
    {
        range = endRange - transform.position.x;
    }

    protected void OnEnable()
    {
        ResetRange();
    }

    protected override void ScanRadar()
    {
        Vector2 posFire = new Vector2(transform.position.x, transform.position.y);
        hit = Physics2D.Raycast(posFire, Vector2.right, range, layer);
        Debug.DrawLine(posFire, new Vector3(posFire.x + range, posFire.y,0), Color.green);
    }
}
