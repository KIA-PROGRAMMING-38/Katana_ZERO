using UnityEngine;

public abstract class AnimationManager : MonoBehaviour
{
    public abstract void SetNextAnimation( int state );

    public abstract void SetNextAnimation();

    public abstract int GetAnimationStateHash( int state );

    public abstract void ActiveAttack();

    public abstract void InActiveAttack();

    public abstract void InvokeThrow();

    public abstract void InvokeSwing();
}
