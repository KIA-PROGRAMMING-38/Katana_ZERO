using UnityEngine;
using StringLiteral;

public class WallgrabStateBehaviour : PlayerState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        rigid.velocity = new Vector2( rigid.velocity.x, data.HoldAWallForce );

        if ( stateInfo.normalizedTime >= data.HoldAWallTime )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.WALL_SLIDE );
        }

        if ( Input.GetButtonDown( InputAxisString.UP_KEY ))
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.WALL_FLIP );
            controller.Flip();
        }

        if ( Input.GetKeyDown( KeyCode.RightArrow ) )
        {
            if ( data.onLeftWall )
            {
                rigid.AddForce( Vector2.right * 2f, ForceMode2D.Impulse );
                data.isWallSliding = false;

                ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.FALL );
            }
        }

        if ( Input.GetKeyDown( KeyCode.LeftArrow ) )
        {
            if ( !data.onLeftWall )
            {
                rigid.AddForce( -Vector2.right * 2f, ForceMode2D.Impulse );
                data.isWallSliding = false;

                ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.FALL );
            }
        }
    }


    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
