using UnityEngine;
using StringLiteral;

public class FallStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        data.moveVec = new Vector2( rigid.velocity.x, -2f );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( Input.GetButton(InputAxisString.DOWN_KEY) )
        {
            data.moveVec.y += data.FallingBoostForce;
        }

        controller.HorizontalMovement();
        controller.CheckedIfWallSliding();

        if ( data.isGrounded )
        {
            ChangeState( animator, PlayerAnimationLiteral.FALL, PlayerAnimationLiteral.IDLE );
        }

        if ( data.isTouchingWall )
        {
            ChangeState( animator, PlayerAnimationLiteral.FALL, PlayerAnimationLiteral.WALL_GRAB );

            if ( data.FlipIsRight )
            {
                data.onLeftWall = false;
            }
            else
            {
                data.onLeftWall = true;
            }
        }

        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
