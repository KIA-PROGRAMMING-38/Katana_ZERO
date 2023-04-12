using UnityEngine;
using LiteralRepository;

public class KissyLungeAttack : BossStateMachine
{
    private KissyfaceAnimInvoker _invokeAnimation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        _invokeAnimation = animator.GetComponent<KissyfaceAnimInvoker>();
        controller.PrevState = KissyfaceAnimeHash.s_LUNGEATTACK;
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
