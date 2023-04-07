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

        if ( data.OnGround )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.IDLE );
        }

        if ( !data.IsTouchingWall )
        {
            if ( rigid.velocity.y < 0f ) 
            {
                ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.FALL );

                return;
            }
        }

        if ( rigid.velocity.y < -data.WallSlideSpeed )
        {
            rigid.velocity = new Vector2( rigid.velocity.x, -data.WallSlideSpeed );
        }

        if ( Input.GetButtonDown(InputAxisString.UP_KEY) )
        {
            controller.Flip();

            ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.WALL_FLIP );
        }

        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            if ( data.OnLeftWall )
            {
                rigid.AddForce( Vector2.right * 4f, ForceMode2D.Impulse );
                data.IsTouchingWall = false;

                ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.FALL );
            }
        }

        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            if ( !data.OnLeftWall )
            {
                rigid.AddForce( -Vector2.right * 4f, ForceMode2D.Impulse );
                data.IsTouchingWall = false;

                ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.FALL );
            }
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_SLIDE, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
