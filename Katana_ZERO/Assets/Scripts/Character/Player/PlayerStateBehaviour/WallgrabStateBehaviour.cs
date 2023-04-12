using UnityEngine;
using LiteralRepository;

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



        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            if ( data.OnLeftWall )
            {
                data.FlipIsRight = !data.FlipIsRight;
                data.PrevStateisGrab = true;
                ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.FALL );
            }
        }

        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            if ( data.OnLeftWall == false )
            {
                data.FlipIsRight = !data.FlipIsRight;
                data.PrevStateisGrab = true;
                ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.FALL );
            }
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.WALL_GRAB, PlayerAnimationLiteral.ATTACK );
        }
    }


    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
