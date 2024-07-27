
public class AnimMachine
{
    private AbstractAnim curAnim;

    public void ChangeAnim(AbstractAnim newAnim)
    {
        if(curAnim != null) curAnim.Exit();
        curAnim = newAnim;
        if(curAnim != null) curAnim.Enter();
    }
}
