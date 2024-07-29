using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMachine
{
    private IAction curAction;

    public void ChangeAction(IAction newAction)
    {
        if(curAction != null) curAction.Exit();
        curAction = newAction;
        if(curAction != null) curAction.Enter();
    }

    public void Update()
    {
        if (curAction == null) return;
        curAction.UpdateLogic();
        curAction.UpdatePhysis();
    }
}
