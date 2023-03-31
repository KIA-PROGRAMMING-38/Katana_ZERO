using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleStateBehaviour : StateMachineBehaviour
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
        if ( _pc.moveVec != Vector2.zero )
        {
            _rigid.MovePosition( _rigid.position + _pc.moveVec );
            animator.SetTrigger( "isRun" );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
