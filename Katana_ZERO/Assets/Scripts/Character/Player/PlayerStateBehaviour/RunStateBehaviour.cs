using UnityEngine;
using StringLiteral;

public class RunStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        controller.HorizontalMovement();

        if ( data.moveVec.x == 0f ) 
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.RUN_TO_IDLE );
        }

        if ( Input.GetButtonDown( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.JUMP );
        }

        if ( rigid.velocity.y < 0 )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.FALL );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
