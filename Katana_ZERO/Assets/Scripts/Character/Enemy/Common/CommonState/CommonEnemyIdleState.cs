using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyIdleState : CommonEnemyState
{
    private float _waitSec;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationHash.s_Idle;
        _waitSec = Random.Range
            ( controller.idleMinSec, controller.idleMaxSec );
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        float deltaTime = Time.deltaTime;

        elapsedTime += deltaTime;

        if ( controller.ThisIsPlayer.layer == LayerMaskNumber.s_DiePlayer )
            return;

        if ( controller.TrackActive )
        {
            ChangeState( animator, EnemyAnimationHash.s_Idle, EnemyAnimationHash.s_Walk );
        }

        if ( elapsedTime > _waitSec )
        {
            if ( controller.PatrolPoints[0] == null )
                return;

            ChangeState( animator, EnemyAnimationHash.s_Idle, EnemyAnimationHash.s_Walk );
        }
    }


    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

    }
}
