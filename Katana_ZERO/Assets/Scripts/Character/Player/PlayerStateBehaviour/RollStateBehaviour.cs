using UnityEngine;
using StringLiteral;

public class RollStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = new Vector2( data.RollHorizontalForce * data.facingDirection, rigid.velocity.y );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, PlayerAnimationLiteral.ROLL, PlayerAnimationLiteral.CROUCH );
        }

        if ( Input.GetButtonDown(InputAxisString.UP_KEY) )
        {
            ChangeState( animator, PlayerAnimationLiteral.ROLL, PlayerAnimationLiteral.JUMP );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigid.velocity = Vector2.zero;
    }
}
