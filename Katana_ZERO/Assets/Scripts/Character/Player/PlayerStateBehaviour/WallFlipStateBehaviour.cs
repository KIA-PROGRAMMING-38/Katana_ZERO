using UnityEngine;
using LiteralRepository;

public class WallFlipStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = new Vector2( data.WallFlipHorizontalForce * data.FacingDirection, data.WallFlipVerticalForce );
        controller.ActiveAfterImage();
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

        if ( data.IsTouchingWall )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_FLIP, PlayerAnimationLiteral.WALL_GRAB );

            if ( data.FlipIsRight )
            {
                data.OnLeftWall = false;
            }
            else
            {
                data.OnLeftWall = true;
            }
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_FLIP, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;
    }
}
