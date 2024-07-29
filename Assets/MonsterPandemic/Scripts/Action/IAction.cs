using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    void Enter();
    void Exit();
    void UpdatePhysis();
    void UpdateLogic();
}
