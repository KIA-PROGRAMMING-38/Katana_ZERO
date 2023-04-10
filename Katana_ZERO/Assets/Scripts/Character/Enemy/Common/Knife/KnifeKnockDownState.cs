using StringLiteral;
using UnityEngine;

public class KnifeKnockDownState : CommonEnemyState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationLiteral.KNOCKDOWN;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;

        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, EnemyAnimationHash.s_KNOCKDOWN, EnemyAnimationHash.s_RUN );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}