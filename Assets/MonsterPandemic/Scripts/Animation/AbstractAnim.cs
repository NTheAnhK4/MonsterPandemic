
using UnityEngine;

public class AbstractAnim
{
    protected string animName;
    protected Animator _animator;

    public AbstractAnim(Animator animator)
    {
        _animator = animator;
    }

   

    public virtual void Enter()
    {
        if (animName == string.Empty) return;
        _animator.SetBool(animName, true);
    }

    public virtual void Exit()
    {
        if (animName == string.Empty) return;
        _animator.SetBool(animName,false);
    }
}
