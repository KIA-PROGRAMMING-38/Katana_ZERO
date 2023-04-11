using StringLiteral;
using UnityEngine;

public class KissyToBattle : BossStateMachine
{
    private int _initialState;
    private KissyfaceProperty _property;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        _initialState = Random.Range( 0, 2 );

        _property = animator.gameObject.transform.root.GetComponent<KissyfaceProperty>();

        controller.PrevState = KissyfaceAnimeHash.s_TOBATTLE;
        getNextStateHash = _property.CheckedNextState( _initialState );
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if ( stateInfo.normalizedTime >= 1f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_TOBATTLE, getNextStateHash );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
