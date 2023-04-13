using LiteralRepository;
using UnityEngine;

public class KnifeKnockDownState : CommonEnemyState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationHash.s_KnockDown;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;

        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, EnemyAnimationHash.s_KnockDown, EnemyAnimationHash.s_Run );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}