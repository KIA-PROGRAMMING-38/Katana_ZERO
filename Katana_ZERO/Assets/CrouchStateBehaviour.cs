using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( Input.GetKeyUp( KeyCode.DownArrow ) )
        {
            animator.SetTrigger( "isReturn" );
        }

        if ( Input.GetKeyDown( KeyCode.UpArrow ) )
        {
            animator.SetTrigger( "isJump" );
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
