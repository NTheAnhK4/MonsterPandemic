using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementFactory
{
    public static Movement CreateMovement(MoveType moveType, Transform obj,float speed, Vector3 direction)
    {
        Movement movement = null;
        switch (moveType)
        {
            case MoveType.Straight:
                movement = new StraightMovement(obj,speed, direction);
                break;
        }

        return movement;
    }
}
