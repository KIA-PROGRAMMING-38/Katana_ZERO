using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class WallgrabStateBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerData _data;
    private PlayerController _controller;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        _rigid = animator.GetComponent<Rigidbody2D>();
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        _rigid.velocity = new Vector2( 0f, 0.7f );

        if ( Input.GetKeyDown( KeyCode.UpArrow ) )
        {
            animator.SetTrigger( "isWallFlip" );
            _controller.Flip();

        }

        if ( Input.GetKeyDown( KeyCode.RightArrow ) )
        {
            if ( _data.onLeftWall )
            {
                _rigid.AddForce( Vector2.right * 2f, ForceMode2D.Impulse );
                _data.isWallSliding = false;
                animator.SetTrigger( "isFall" );
            }

        }

        if ( Input.GetKeyDown( KeyCode.LeftArrow ) )
        {
            if ( !_data.onLeftWall )
            {
                _rigid.AddForce( -Vector2.right * 2f, ForceMode2D.Impulse );
                _data.isWallSliding = false;
                animator.SetTrigger( "isFall" );
            }
        }
    }


    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {

    }
}
