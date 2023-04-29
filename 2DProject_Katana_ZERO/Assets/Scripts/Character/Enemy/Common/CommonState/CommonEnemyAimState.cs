using LiteralRepository;
using UnityEngine;
using Util;

public class CommonEnemyAimState : CommonEnemyState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.zero;
        controller.PrevState = EnemyAnimationHash.s_Aim;

        if ( controller.ThisEnemyType == Enemy.CommonEnemyType.Gun )
        {
            controller.OnEnableGunArms();
        }

        if ( controller.EnemyOnGround == GlobalData.GroundState.Slope )
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;

        if ( elapsedTime >= controller.attackCooltime )
        {
            ChangeState( animator, EnemyAnimationHash.s_Aim, EnemyAnimationHash.s_Attack );
        }

        if ( controller.AttackActive == false )
        {
            ChangeState( animator, EnemyAnimationHash.s_Aim, EnemyAnimationHash.s_Run );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
