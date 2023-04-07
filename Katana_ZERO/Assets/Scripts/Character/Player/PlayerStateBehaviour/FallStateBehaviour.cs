using UnityEngine;
using StringLiteral;

public class FallStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        if ( data.PrevStateisGrab )
        {
            rigid.AddForce( input.PrimitiveMoveVec * 4f, ForceMode2D.Impulse );
            data.PrevStateisGrab = false;
            data.FlipIsRight = !data.FlipIsRight;
        }
        else
        {
            data.MoveVec = new Vector2( rigid.velocity.x, -2f );
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( Input.GetButton(InputAxisString.DOWN_KEY) )
        {
            data.MoveVec.y += data.FallingBoostForce;
        }

        controller.HorizontalMovement();
        controller.CheckedIfWallSliding();

        if ( data.OnGround )
        {
            ChangeState( animator, PlayerAnimationLiteral.FALL, PlayerAnimationLiteral.IDLE );
        }

        if ( data.IsTouchingWall )
        {
            ChangeState( animator, PlayerAnimationLiteral.FALL, PlayerAnimationLiteral.WALL_GRAB );

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
            ChangeState( animator, PlayerAnimationLiteral.FALL, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
