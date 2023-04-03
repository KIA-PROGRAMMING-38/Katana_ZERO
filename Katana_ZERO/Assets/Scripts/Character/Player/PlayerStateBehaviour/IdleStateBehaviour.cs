using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateBehaviour : StateMachineBehaviour
{
    private PlayerData _data;
    private PlayerController _controller;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( _data.moveVec.x != 0f )
        {
            animator.SetTrigger( "isRun" );
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
