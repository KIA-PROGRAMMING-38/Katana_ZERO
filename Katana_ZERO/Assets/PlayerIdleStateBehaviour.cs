using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleStateBehaviour : StateMachineBehaviour
{
    private PlayerController _pc;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _pc = animator.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( _pc.moveVec != Vector2.zero )
        {
            animator.SetTrigger( "isRun" );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
