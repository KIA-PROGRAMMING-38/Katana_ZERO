using UnityEngine;
using StringLiteral;

public class IdletoRunStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        data.moveVec /= 2f;
        controller.HorizontalMovement();

        if (stateInfo.normalizedTime >= 0.8f )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE_TO_RUN, PlayerAnimationLiteral.RUN );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
