using UnityEngine;
using StringLiteral;

public class Knife_IdleStateBehaviour : KnifeState
{
    private float _waitSec;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

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
            ChangeState( animator, EnemyAnimationLiteral.IDLE, EnemyAnimationLiteral.WALK );
        }

        if ( controller.TrackActive )
        {
            ChangeState( animator, EnemyAnimationLiteral.IDLE, EnemyAnimationLiteral.RUN );
        }
    }


    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

    }
}
