using StringLiteral;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Run State == Track
public class CommonEnemyRunState : CommonEnemyState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationLiteral.RUN;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        _trackVec = (controller.TargetTransform.position - (Vector3)rigid.position).normalized;

        rigid.velocity = _trackVec * controller.runSpeed;

        if ( controller.AttackActive )
        {
            ChangeState( animator, EnemyAnimationHash.s_RUN, EnemyAnimationHash.s_AIM );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
