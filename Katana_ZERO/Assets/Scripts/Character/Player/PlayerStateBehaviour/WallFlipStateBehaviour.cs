using UnityEngine;
using StringLiteral;

public class WallFlipStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = new Vector2( data.wallFlipHorizontalForce * data.facingDirection, data.wallFlipVerticalForce );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( rigid.velocity.y < 1f )
        {
            rigid.velocity = new Vector2( rigid.velocity.x, 1f );
        }

        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_FLIP, PlayerAnimationLiteral.FALL );
        }

        if ( data.isTouchingWall )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_FLIP, PlayerAnimationLiteral.WALL_GRAB );

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

        rigid.velocity = Vector2.zero;
    }
}
