using LiteralRepository;
using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyToBattle : BossStateMachine
{
    private int _initialState;
    private KissyfaceAnimInvoker _animInvoker;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        _initialState = Random.Range( 0, 2 );

        currentKissyState = KissyState.ToBattle;
        getNextStateHash = _animInvoker.NextBehaviour( _initialState );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_ToBattle, getNextStateHash );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
