using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleStateBehaviour : StateMachineBehaviour
{
    private PlayerController _pc;
    private PlayerInput _pi;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _pc = animator.GetComponent<PlayerController>();
        _pi = animator.GetComponent<PlayerInput>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( _pi.primitiveMoveVec != Vector2.zero )
        {
            animator.SetTrigger( "isRun" );
        }

        if ( _pi.primitiveJumpVec != Vector2.zero )
        {
            animator.SetTrigger( "isJump" );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
