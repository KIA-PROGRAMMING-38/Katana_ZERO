using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallFlipStateBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerData _data;
    private PlayerController _controller;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigid = animator.GetComponent<Rigidbody2D>();
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();

        _rigid.velocity = new Vector2( _data.wallFlipHorizontalForce * _data.facingDirection, _data.wallFlipVerticalForce );

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_rigid.velocity.y < 1f )
        {
            _rigid.velocity = new Vector2( _rigid.velocity.x, 1f );
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
        if ( !_data.FlipIsRight )
        {
            _rigid.velocity = new Vector2( _rigid.velocity.x + 2f, -1f );
        }
        else
        {
            _rigid.velocity = new Vector2( _rigid.velocity.x - 2f, -1f );
        }
        
    }
}
