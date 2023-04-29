using UnityEngine;
using LiteralRepository;
using Util;
using static PlayerAnimInvoker;

public class RollStateBehaviour : PlayerState
{
    private float CatureDirection;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        // 현재 상태 저장
        CurrentPlayerState = PlayerAnimInvoker.PlayerState.Roll;
        // Update에서 실행되는 RollMovement에 영향을 주는 플레이어의 입력 direction을 캡쳐
        CatureDirection = input.PrimitiveMoveVec.x;
        // Roll 상태에서는 먼지구름 이펙트가 발생
        footParticle.Play();
        // Roll 상태에서는 공격받지 않는 상태여야함. 무적 레이어 전환
        controller.gameObject.layer = LayerMaskNumber.s_ImmunityState;
        // Roll 상태에서는 잔상 이펙트 효과 On
        controller.ActiveAfterImage();

        audio.PlayEffectSound( 0 );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( data.PlayerOnGround == GlobalData.GroundState.Flat || data.PlayerOnGround == GlobalData.GroundState.OneWay )
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

    /// <summary>
    /// GrondState가 Flat일 때 계산되는 Movement
    /// </summary>
    private void FlatGroundRollMovement()
    {
        rigid.velocity = new Vector2
            ( data.RollHorizontalForce * CatureDirection, 0f );
    } 

    /// <summary>
    /// GrondState가 Slope일 때 계산되는 Movement
    /// </summary>
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
