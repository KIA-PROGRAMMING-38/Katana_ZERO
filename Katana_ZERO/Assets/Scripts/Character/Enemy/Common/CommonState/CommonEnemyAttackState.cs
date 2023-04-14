using LiteralRepository;
using UnityEngine;

public class CommonEnemyAttackState : CommonEnemyState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.isShot = true;
        controller.PrevState = EnemyAnimationHash.s_Attack;
        controller.OnDamageable = false;

        if ( controller.ThisEnemyType == Enemy.CommonEnemyType.Gun )
        {
            controller.GunReadyToAttack();
        }
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;

        if ( controller.AttackActive == false )
        {
            ChangeState( animator, EnemyAnimationHash.s_Attack, EnemyAnimationHash.s_Run );
        }

        if ( elapsedTime >= controller.attackCooltime )
        {
            ChangeState( animator, EnemyAnimationHash.s_Attack, EnemyAnimationHash.s_Aim );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        controller.isShot = false;

        if ( controller.ThisEnemyType == Enemy.CommonEnemyType.Gun )
        {
            controller.GunRestoreCondition();
        }
    }
}
