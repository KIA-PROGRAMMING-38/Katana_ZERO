using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class AnimationManager : MonoBehaviour
{
    protected Animator animator;

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public abstract void SetNextAnimation( int state );

    public abstract void SetAnimationTrigger( string state );

    public abstract int GetAnimationStateHash( int state );
}
