using LiteralRepository;
using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyIdle : BossStateMachine
{
    private KissyfaceAnimInvoker _animInvoke;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _animInvoke = animator.transform.root.GetComponent<KissyfaceAnimInvoker>();

        currentKissyState = KissyState.Idle;
        getNextStateHash = _animInvoke.NextBehaviour();
        CheckedDirection();
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        ChangeState( animator, KissyfaceAnimeHash.s_Idle, getNextStateHash );
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
