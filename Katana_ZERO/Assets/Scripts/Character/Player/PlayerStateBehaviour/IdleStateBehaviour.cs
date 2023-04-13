using UnityEngine;
using LiteralRepository;

public class IdleStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if ( data.MoveVec.x != 0f )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE, PlayerAnimationLiteral.IDLE_TO_RUN );
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE, PlayerAnimationLiteral.ATTACK );
        }

        if ( Input.GetButtonDown(InputAxisString.UP_KEY) )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE, PlayerAnimationLiteral.JUMP );
        }

        if ( Input.GetButton(InputAxisString.DOWN_KEY) )
        {
            ChangeState( animator, PlayerAnimationLiteral.IDLE, PlayerAnimationLiteral.PRE_CROUCH );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
