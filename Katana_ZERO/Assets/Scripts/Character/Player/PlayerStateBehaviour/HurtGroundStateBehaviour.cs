using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class HurtGroundStateBehaviour : PlayerState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.DrawBlood.StopDrawBlood();
        controller.ImpactBlood.TargetObject.Add( animator.gameObject );
        controller.ImpactBlood.ImpactCall( controller.ImpactBlood.TargetObject.Count - 1 );
        data.IsDie = true;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
