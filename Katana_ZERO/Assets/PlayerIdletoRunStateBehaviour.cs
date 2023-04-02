using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdletoRunStateBehaviour : StateMachineBehaviour
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
        _rigid.velocity = _pc.moveVec / 2f;
    }
}
