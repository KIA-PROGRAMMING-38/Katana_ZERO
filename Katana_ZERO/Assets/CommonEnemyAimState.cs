using StringLiteral;
using UnityEngine;

public class CommonEnemyAimState : CommonEnemyState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;
        controller.PrevState = EnemyAnimationLiteral.AIM;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;

        if ( elapsedTime >= controller.attackCooltime )
        {
            ChangeState( animator, EnemyAnimationHash.s_AIM, EnemyAnimationHash.s_ATTACK );
        }

        if ( controller.AttackActive == false )
        {
            ChangeState( animator, EnemyAnimationHash.s_AIM, EnemyAnimationHash.s_RUN );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
