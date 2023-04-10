using StringLiteral;
using UnityEngine;

public class Knife_AttackStateBehaviour : KnifeState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;
        controller.PrevState = EnemyAnimationLiteral.ATTACK;
        controller.OnDamageable = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

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
