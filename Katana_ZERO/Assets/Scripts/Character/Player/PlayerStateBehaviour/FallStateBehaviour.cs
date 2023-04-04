using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStateBehaviour : StateMachineBehaviour
{
    private PlayerData _data;
    private PlayerController _controller;
    private Rigidbody2D _rigid;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();
        _rigid = animator.GetComponent<Rigidbody2D>();

        _data.moveVec = new Vector2( _rigid.velocity.x, -2f );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            _data.moveVec.y += _data.FallingBoostForce;
        }

        _controller.HorizontalMovement();
        _controller.CheckedIfWallSliding();


        if ( _data.isGrounded )
        {
            animator.SetTrigger( "isReturn" );
        }

        if ( _data.isTouchingWall )
        {
            animator.SetTrigger( "isWallgrab" );

            if ( _data.FlipIsRight )
            {
                _data.onLeftWall = false;
            }
            else
            {
                _data.onLeftWall = true;
            }
        }

        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
