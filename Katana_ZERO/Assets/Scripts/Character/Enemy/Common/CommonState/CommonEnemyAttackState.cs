using LiteralRepository;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CommonEnemyAttackState : CommonEnemyState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationHash.s_ATTACK;
        controller.isShot = true;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;

        if ( controller.AttackActive == false )
        {
            ChangeState( animator, EnemyAnimationHash.s_ATTACK, EnemyAnimationHash.s_RUN );
        }

        if ( elapsedTime >= 1f )
        {
            ChangeState( animator, EnemyAnimationHash.s_ATTACK, EnemyAnimationHash.s_AIM );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        controller.isShot = false;
    }
}
