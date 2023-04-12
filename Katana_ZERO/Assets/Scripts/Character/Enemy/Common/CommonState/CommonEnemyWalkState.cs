using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyWalkState : CommonEnemyState
{
    private float _patrolSec;

    private int _currentPointIndex = 0;

    private Vector3 _nextPoint;
    private Vector2 _moveVec;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _patrolSec = Random.Range
            ( controller.patrolMinSec, controller.patrolMaxSec );
        _nextPoint = controller.PatrolPoints[_currentPointIndex].position;

        controller.PrevState = EnemyAnimationHash.s_WALK;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        float deltaTime = Time.deltaTime;
        elapsedTime += deltaTime;

        if ( elapsedTime >= _patrolSec )
        {
            ChangeState( animator, EnemyAnimationHash.s_WALK, EnemyAnimationHash.s_IDLE );
        }

        if ( Vector2.Distance( controller.transform.position, _nextPoint ) <= 0.1f )
        {
            SetNextPoint();
        }

        _moveVec = new Vector2( controller.walkSpeed * controller.FacingDirection, rigid.velocity.y );
        rigid.velocity = _moveVec;

        if ( controller.TrackActive )
        {
            ChangeState( animator, EnemyAnimationHash.s_WALK, EnemyAnimationHash.s_RUN );
        }
    }

    private void SetNextPoint()
    {
        _currentPointIndex = ( _currentPointIndex + 1 ) % 2;
        _nextPoint = controller.PatrolPoints[_currentPointIndex].position;
        controller.Flip();
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
