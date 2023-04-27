using LiteralRepository;
using UnityEngine;
using Util;
using static PlayerAnimInvoker;

public class CrouchStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        CurrentPlayerState = PlayerAnimInvoker.PlayerState.Crouch;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if ( data.PlayerOnGround == GlobalData.GroundState.Slope )
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        if ( !Input.GetButton( InputAxisString.DOWN_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.CROUCH, PlayerAnimationLiteral.POST_CROUCH );
        }

        if ( Input.GetButton( InputAxisString.UP_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.CROUCH, PlayerAnimationLiteral.JUMP );
        }

        if ( Input.GetButtonDown( InputAxisString.HORIZONTAL_KEY ) )
        {
            ChangeState( animator, PlayerAnimationLiteral.CROUCH, PlayerAnimationLiteral.ROLL );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
