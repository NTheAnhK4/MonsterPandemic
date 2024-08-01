

using UnityEngine;

public class ActionMachine
{
    private IAction curAction;

    public bool ChangeAction(IAction newAction)
    {
        if (curAction != null && newAction != null && newAction.GetType() == curAction.GetType()) return false;
        if(curAction != null) curAction.Exit();
        curAction = newAction;
        if(curAction != null) curAction.Enter();
        return true;
    }

    public void Update()
    {
        if (curAction == null) return;
        curAction.UpdateLogic();
        curAction.UpdatePhysis();
    }

    public void SetSpeed(float newSpeed)
    {
        if (curAction is not Movement movement) return;
        movement.Speed = newSpeed;
    }
    public int GetAttackCount()
    {
        if (curAction is not Attack attack) return 0;
        return attack.GetAttackCount();
    }

    public void GetCurAction()
    {
        Debug.Log(curAction);
    }
}
