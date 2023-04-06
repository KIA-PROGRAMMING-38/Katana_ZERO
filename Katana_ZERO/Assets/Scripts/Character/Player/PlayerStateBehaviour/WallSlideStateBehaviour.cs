using UnityEngine;
using StringLiteral;

public class WallSlideStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( data.isGrounded )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.IDLE );
        }

        if ( !data.isTouchingWall )
        {
            if ( rigid.velocity.y < 0f ) 
            {
                ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.FALL );

                return;
            }
        }

        if ( rigid.velocity.y < -data.wallSlideSpeed )
        {
            rigid.velocity = new Vector2( rigid.velocity.x, -data.wallSlideSpeed );
        }

        if ( Input.GetButtonDown(InputAxisString.UP_KEY) )
        {
            controller.Flip();

            ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.WALL_FLIP );
        }

        if ( Input.GetKeyDown( KeyCode.RightArrow ) )
        {
            if ( data.onLeftWall )
            {
                rigid.AddForce( Vector2.right * 2f, ForceMode2D.Impulse );
                data.isTouchingWall = false;

                ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.FALL );
            }

        }

        if ( Input.GetKeyDown( KeyCode.LeftArrow ) )
        {
            if ( !data.onLeftWall )
            {
                rigid.AddForce( -Vector2.right * 2f, ForceMode2D.Impulse );
                data.isTouchingWall = false;

                ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.FALL );
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
