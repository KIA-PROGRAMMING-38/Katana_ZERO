using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStateBehaviour : StateMachineBehaviour
{
    private PlayerData _data;
    private PlayerController _controller;
    private Rigidbody2D _rigid;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();
        _rigid = animator.GetComponent<Rigidbody2D>();

        _controller.Jump();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _controller.CheckedIfWallSliding();

        if ( _rigid.velocity.y < 0 )
        {
            animator.SetTrigger( "isFall" );
        }

        if ( _data.isTouchingWall )
        {
            animator.SetTrigger( "isWallgrab" );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
