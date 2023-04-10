using StringLiteral;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyIdleState : CommonEnemyState
{
    private float _waitSec;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationLiteral.IDLE;
        _waitSec = Random.Range
            ( controller.idleMinSec, controller.idleMaxSec );
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        float deltaTime = Time.deltaTime;

        elapsedTime += deltaTime;

        if ( elapsedTime > _waitSec )
        {
            ChangeState( animator, EnemyAnimationHash.s_IDLE, EnemyAnimationHash.s_WALK );
        }

        if ( controller.TrackActive )
        {
            ChangeState( animator, EnemyAnimationHash.s_IDLE, EnemyAnimationHash.s_WALK );
        }
    }


    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

    }
}
