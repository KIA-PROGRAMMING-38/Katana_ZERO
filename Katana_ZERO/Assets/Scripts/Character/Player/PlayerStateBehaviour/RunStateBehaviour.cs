using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class RunStateBehaviour : StateMachineBehaviour
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
        _controller.HorizontalMovement();

        if ( _data.moveVec == Vector2.zero ) 
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
