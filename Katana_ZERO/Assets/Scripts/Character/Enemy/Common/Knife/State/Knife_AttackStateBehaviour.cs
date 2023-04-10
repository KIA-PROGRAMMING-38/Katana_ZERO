using StringLiteral;
using UnityEngine;

public class Knife_AttackStateBehaviour : KnifeState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.ShotCooltime = 0f;

        Debug.Log( "공격 진입" );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( controller.TrackActive == false )
        {
            ChangeState( animator, EnemyAnimationLiteral.ATTACK, EnemyAnimationLiteral.RETURN );
        }

        if ( controller.AttackActive == false )
        {
            ChangeState( animator, EnemyAnimationLiteral.ATTACK, EnemyAnimationLiteral.RUN );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

    }
}
