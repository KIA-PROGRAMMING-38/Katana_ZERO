using UnityEngine;
using StringLiteral;

public class JumpStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.Jump();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        controller.CheckedIfWallSliding();

        if ( rigid.velocity.y < 0 )
        {
            ChangeState( animator, PlayerAnimationLiteral.JUMP, PlayerAnimationLiteral.FALL );
        }

        if ( data.isTouchingWall )
        {
            ChangeState( animator, PlayerAnimationLiteral.JUMP, PlayerAnimationLiteral.WALL_GRAB );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        animator.SetBool( "isJump", false );
    }
}
