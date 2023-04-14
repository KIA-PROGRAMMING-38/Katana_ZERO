using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyDie : BossStateMachine
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        currentKissyState = KissyState.Die;
        controller.PrevState = (int)KissyState.Die;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        controller.TargetGameObject.gameObject.SetActive( true );
    }
}
