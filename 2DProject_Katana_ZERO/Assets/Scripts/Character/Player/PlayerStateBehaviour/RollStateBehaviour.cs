using UnityEngine;
using LiteralRepository;

public class RollStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = new Vector2
            ( data.RollHorizontalForce * input.PrimitiveMoveVec.x, rigid.velocity.y );
        footParticle.Play();
        controller.gameObject.layer = LayerMaskNumber.s_ImmunityState;
        controller.ActiveAfterImage();
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
}
