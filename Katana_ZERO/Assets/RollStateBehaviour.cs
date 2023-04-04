using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollStateBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rigid;
    private PlayerData _data;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigid = animator.GetComponent<Rigidbody2D>();
        _data = animator.GetComponent<PlayerData>();

        _rigid.velocity = new Vector2( _data.RollHorizontalForce * _data.facingDirection, _rigid.velocity.y );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( Input.GetKeyDown( KeyCode.UpArrow ) )
        {
            animator.SetTrigger( "isJump" );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigid.velocity = Vector2.zero;
    }
}
