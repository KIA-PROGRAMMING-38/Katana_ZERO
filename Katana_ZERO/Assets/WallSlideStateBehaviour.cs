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
        if ( _data.isGrounded )
        {
            animator.SetTrigger( "isReturn" );
        }

        if ( _rigid.velocity.y < -_data.wallSlideSpeed )
        {
            _rigid.velocity = new Vector2( _rigid.velocity.x, -_data.wallSlideSpeed );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
