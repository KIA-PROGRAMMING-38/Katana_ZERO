using StringLiteral;
using UnityEngine;

public class CrouchStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if ( !Input.GetButton( InputAxisString.DOWN_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.CROUCH, PlayerAnimationLiteral.POST_CROUCH );
        }

        if ( Input.GetButton( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.CROUCH, PlayerAnimationLiteral.JUMP );
        }

        if ( Input.GetButtonDown( InputAxisString.HORIZONTAL_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.CROUCH, PlayerAnimationLiteral.ROLL );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}