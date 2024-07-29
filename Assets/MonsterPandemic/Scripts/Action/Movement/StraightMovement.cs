using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : Movement
{
   
    private Vector3 _direction;
   

    public StraightMovement(Transform obj, float speed, Vector3 direction) : base(obj, speed)
    {
        _direction = direction;
    }

   

    public override void UpdatePhysis()
    {
        
       _obj.Translate(_direction * _speed * Time.deltaTime);
    }

    
}
