using StringLiteral;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class KissyIdle : BossStateMachine
{
    private KissyfaceProperty _property;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _property = animator.transform.root.GetComponent<KissyfaceProperty>();

        controller.PrevState = KissyfaceAnimeHash.s_IDLE;
        getNextStateHash = _property.NextBehaviour();
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        ChangeState( animator, KissyfaceAnimeHash.s_IDLE, getNextStateHash );
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
