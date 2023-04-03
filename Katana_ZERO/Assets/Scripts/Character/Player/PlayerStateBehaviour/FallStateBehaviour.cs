using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStateBehaviour : StateMachineBehaviour
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

        if ( _data.isGrounded )
        {
            animator.SetTrigger( "isReturn" );
        }

        if ( _data.isWallSliding )
        {
            animator.SetTrigger( "isWallgrab" );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
