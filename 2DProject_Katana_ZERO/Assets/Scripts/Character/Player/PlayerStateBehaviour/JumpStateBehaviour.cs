using UnityEngine;
using LiteralRepository;
using static PlayerAnimInvoker;

public class JumpStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.Jump();
        CurrentPlayerState = PlayerAnimInvoker.PlayerState.Jump;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        controller.CheckedJumpFlip();
        controller.CheckedIfWallSliding();

        if ( rigid.velocity.y < 0 )
        {
            ChangeState( animator, PlayerAnimationLiteral.JUMP, PlayerAnimationLiteral.FALL );
        }

        if ( data.IsTouchingWall )
        {
            ChangeState( animator, PlayerAnimationLiteral.JUMP, PlayerAnimationLiteral.WALL_GRAB );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.JUMP, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        animator.SetBool( "isJump", false );
    }
}
