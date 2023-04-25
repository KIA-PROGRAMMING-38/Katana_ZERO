using LiteralRepository;
using UnityEngine;

// Run State == Track
public class CommonEnemyRunState : CommonEnemyState
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationHash.s_Run;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        _trackVec = (controller.TargetTransform.position - (Vector3)rigid.position).normalized;

        rigid.velocity = new Vector2 ((_trackVec * controller.runSpeed).x, 0f);

        if ( controller.AttackActive )
        {
            ChangeState( animator, EnemyAnimationHash.s_Run, EnemyAnimationHash.s_Aim );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
