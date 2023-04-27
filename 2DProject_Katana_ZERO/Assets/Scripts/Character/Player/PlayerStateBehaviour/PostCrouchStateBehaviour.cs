using LiteralRepository;
using UnityEngine;
using Util;
using static PlayerAnimInvoker;

public class PostCrouchStateBehaviour : PlayerState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        CurrentPlayerState = PlayerAnimInvoker.PlayerState.PostCrouch;

        if ( data.PlayerOnGround == GlobalData.GroundState.Slope )
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
