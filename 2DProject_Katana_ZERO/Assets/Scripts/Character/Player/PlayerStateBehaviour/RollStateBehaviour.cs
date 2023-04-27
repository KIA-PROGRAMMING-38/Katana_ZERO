using UnityEngine;
using LiteralRepository;
using Util;
using static PlayerAnimInvoker;

public class RollStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

  
        CurrentPlayerState = PlayerAnimInvoker.PlayerState.Roll;

        CatureDirection = input.PrimitiveMoveVec.x;
        footParticle.Play();
        controller.gameObject.layer = LayerMaskNumber.s_ImmunityState;
        controller.ActiveAfterImage();
    }

    private float CatureDirection;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( data.PlayerOnGround == GlobalData.GroundState.Flat )
        {
            FlatGroundRollMovement();
        }
        else if ( data.PlayerOnGround == GlobalData.GroundState.Slope )
        {
            SlopeGroundRollMovement();
        }

        if ( Input.GetButtonDown(InputAxisString.UP_KEY) )
        {
            ChangeState( animator, PlayerAnimationLiteral.ROLL, PlayerAnimationLiteral.JUMP );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.ROLL, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigid.velocity = Vector2.zero;
        footParticle.Stop();
        controller.gameObject.layer = LayerMaskNumber.s_Player;
    }

    private void FlatGroundRollMovement()
    {
        rigid.velocity = new Vector2
            ( data.RollHorizontalForce * CatureDirection, 0f );
    } 

    private void SlopeGroundRollMovement()
    {
        if ( controller.IsClimb )
        {
            rigid.velocity = new Vector2
                     ( controller.slopeRollForce * CatureDirection, rigid.velocity.y );
        }
        else
        {
            rigid.velocity = new Vector2
                     ( controller.slopeRollForce * CatureDirection,
                     rigid.velocity.y - controller.downRollVelocityForce );
        }
    }
}
