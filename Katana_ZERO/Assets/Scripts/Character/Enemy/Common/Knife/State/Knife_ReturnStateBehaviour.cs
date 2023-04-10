using StringLiteral;
using UnityEngine;

public class Knife_ReturnStateBehaviour : KnifeState
{
    private Vector2 _trackVec;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        Debug.Log( "리턴 진입" );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        _trackVec = new Vector2( controller.runSpeed * controller.FacingDirection, rigid.velocity.y );
        rigid.velocity = _trackVec;

        // Debug.Log( Vector3.Distance( controller.transform.position, controller.OriginPoint ) );
        if ( Vector3.Distance(controller.transform.position, controller.OriginPoint) < 0.001f )
        {
            ChangeState( animator, EnemyAnimationLiteral.RETURN, EnemyAnimationLiteral.IDLE );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

    }
}
