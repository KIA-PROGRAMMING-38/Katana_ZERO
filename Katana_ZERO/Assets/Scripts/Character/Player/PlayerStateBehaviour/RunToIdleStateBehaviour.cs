using LiteralRepository;
using UnityEngine;
using static PlayerAnimInvoker;

public class RunToIdleStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        CurrentPlayerState = PlayerAnimInvoker.PlayerState.RunToIdle;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( stateInfo.normalizedTime >= 0.8f )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN_TO_IDLE, PlayerAnimationLiteral.IDLE );
        }

        if ( Input.GetButtonDown( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.JUMP );
        }

        if ( rigid.velocity.y < 0 )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.FALL );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.RUN, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

    }
}
