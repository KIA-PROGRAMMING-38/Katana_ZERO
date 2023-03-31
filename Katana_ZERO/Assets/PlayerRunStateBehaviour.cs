using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunStateBehaviour : StateMachineBehaviour
{
    private PlayerController _pc;
    private Rigidbody2D _rigid;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _pc = animator.GetComponent<PlayerController>();
        _rigid = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ( _pc.moveVec == Vector2.zero )
        {
            animator.SetTrigger( "isReturn" );
        }

        _rigid.MovePosition( _rigid.position + _pc.moveVec );
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}