using static KissyfaceAnimInvoker;
using UnityEngine;

public class KissyPreJump : BossStateMachine
{
    private float _jumpForce = 8f;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        rigid.velocity = Vector2.up * _jumpForce;
        currentKissyState = KissyState.PreJump;
        controller.PrevState = (int)KissyState.PreJump;
        CheckedDirection();
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
