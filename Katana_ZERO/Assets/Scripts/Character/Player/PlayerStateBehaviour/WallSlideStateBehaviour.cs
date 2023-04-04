using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideStateBehaviour : StateMachineBehaviour
{
    private PlayerData _data;
    private PlayerController _controller;
    private Rigidbody2D _rigid;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();
        _rigid = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( _data.isGrounded || !_data.isTouchingWall )
        {
            animator.SetTrigger( "isReturn" );
        }

        if ( _rigid.velocity.y < -_data.wallSlideSpeed )
        {
            _rigid.velocity = new Vector2( _rigid.velocity.x, -_data.wallSlideSpeed );
        }


        if ( Input.GetKeyDown( KeyCode.UpArrow ) )
        {
            _controller.Flip();

            animator.SetTrigger( "isWallFlip" );
        }

        if ( Input.GetKeyDown( KeyCode.RightArrow ) )
        {
            if ( _data.onLeftWall )
            {
                _rigid.AddForce( Vector2.right * 2f, ForceMode2D.Impulse );
                _data.isTouchingWall = false;
                animator.SetTrigger( "isFall" );
            }

        }

        if ( Input.GetKeyDown( KeyCode.LeftArrow ) )
        {
            if ( !_data.onLeftWall )
            {
                _rigid.AddForce( -Vector2.right * 2f, ForceMode2D.Impulse );
                _data.isTouchingWall = false;
                animator.SetTrigger( "isFall" );
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
