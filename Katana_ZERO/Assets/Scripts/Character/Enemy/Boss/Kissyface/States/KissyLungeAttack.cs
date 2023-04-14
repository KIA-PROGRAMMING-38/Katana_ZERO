using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyLungeAttack : BossStateMachine
{
    private KissyfaceAnimInvoker _invokeAnimation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        _invokeAnimation = animator.GetComponent<KissyfaceAnimInvoker>();
        currentKissyState = KissyState.LungeAttack;
        controller.PrevState = (int)KissyState.LungeAttack;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        _invokeAnimation.InActiveAttack();
    }
}
