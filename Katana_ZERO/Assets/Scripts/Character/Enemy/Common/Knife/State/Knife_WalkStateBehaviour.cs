using UnityEngine;
using StringLiteral;

// State == Patrol
public class Knife_WalkStateBehaviour : KnifeState
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

        Debug.Log( "walk ÁøÀÔ" );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        float deltaTime = Time.deltaTime;
        elapsedTime += deltaTime;

        if ( elapsedTime >= _patrolSec )
        {
            ChangeState( animator, EnemyAnimationLiteral.WALK, EnemyAnimationLiteral.IDLE );
        }

        if ( Vector3.Distance( controller.transform.position, _nextPoint ) < 0.001f )
        {
            SetNextPoint();
        }

        _moveVec = new Vector2( controller.walkSpeed * controller.FacingDirection, rigid.velocity.y );
        rigid.velocity = _moveVec;

        if ( controller.TrackActive )
        {
            ChangeState( animator, EnemyAnimationLiteral.WALK, EnemyAnimationLiteral.RUN );
        }
    }

    private void SetNextPoint()
    {
        _currentPointIndex = ( _currentPointIndex + 1 ) % 2;
        _nextPoint = controller.PatrolPoints[_currentPointIndex].position;
        controller.Flip();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
