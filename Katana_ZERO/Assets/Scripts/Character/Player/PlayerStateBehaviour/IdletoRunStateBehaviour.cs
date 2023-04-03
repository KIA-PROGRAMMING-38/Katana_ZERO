using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdletoRunStateBehaviour : StateMachineBehaviour
{
    private PlayerData _data;
    private PlayerController _controller;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _data = animator.GetComponent<PlayerData>();
        _controller = animator.GetComponent<PlayerController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _data.moveVec /= 2f;
        _controller.HorizontalMovement();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
