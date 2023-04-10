using UnityEngine;
using StringLiteral;

// State == Track
public class Knife_RunStateBehaviour : KnifeState
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = EnemyAnimationLiteral.RUN;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        _trackVec = (controller.TargetTransform.position - (Vector3)rigid.position).normalized;

        rigid.velocity = _trackVec * controller.runSpeed;

        if ( controller.AttackActive )
        {
            ChangeState( animator, EnemyAnimationLiteral.RUN, EnemyAnimationLiteral.ATTACK );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }

    
}
