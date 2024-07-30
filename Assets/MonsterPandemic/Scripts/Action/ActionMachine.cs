

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

    public int GetAttackCount()
    {
        if (curAction is not Attack attack) return 0;
        return attack.GetAttackCount();
    }
}
