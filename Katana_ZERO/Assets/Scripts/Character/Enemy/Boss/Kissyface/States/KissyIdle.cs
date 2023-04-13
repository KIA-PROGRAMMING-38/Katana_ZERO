using LiteralRepository;
using UnityEngine;

public class KissyIdle : BossStateMachine
{
    private KissyfaceProperty _property;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _property = animator.transform.root.GetComponent<KissyfaceProperty>();

        controller.PrevState = KissyfaceAnimeHash.s_Idle;
        getNextStateHash = _property.NextBehaviour();
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
