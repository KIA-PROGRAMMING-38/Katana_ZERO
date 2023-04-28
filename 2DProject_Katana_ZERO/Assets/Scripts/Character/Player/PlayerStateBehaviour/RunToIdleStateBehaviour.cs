using LiteralRepository;
using UnityEngine;
using Util;
using static PlayerAnimInvoker;

public class RunToIdleStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        CurrentPlayerState = PlayerAnimInvoker.PlayerState.RunToIdle;

        if ( data.PlayerOnGround == GlobalData.GroundState.Slope )
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( Input.GetButtonDown( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN_TO_IDLE, PlayerAnimationLiteral.JUMP );
        }

        if ( rigid.velocity.y < 0 && !data.OnGround )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN_TO_IDLE, PlayerAnimationLiteral.FALL );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN_TO_IDLE, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
