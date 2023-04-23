using UnityEngine;
using LiteralRepository;
using static PlayerAnimInvoker;

public class IdletoRunStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        footParticle.Play();
        CurrentPlayerState = PlayerAnimInvoker.PlayerState.IdleToRun;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        data.MoveVec /= 2f;
        controller.HorizontalMovement();

        if (stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE_TO_RUN, PlayerAnimationLiteral.RUN );
        }

        if ( Input.GetButtonDown( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE_TO_RUN, PlayerAnimationLiteral.JUMP );
        }

        if ( rigid.velocity.y < 0 )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE_TO_RUN, PlayerAnimationLiteral.FALL );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE_TO_RUN, PlayerAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        footParticle.Stop();
    }
}
