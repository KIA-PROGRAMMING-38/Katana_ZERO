using UnityEngine;
using StringLiteral;

public class PreCrouchStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, PlayerAnimationLiteral.PRE_CROUCH, PlayerAnimationLiteral.CROUCH );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}