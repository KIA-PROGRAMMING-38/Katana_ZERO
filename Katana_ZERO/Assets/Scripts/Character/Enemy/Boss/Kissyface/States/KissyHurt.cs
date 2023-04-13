using LiteralRepository;
using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyHurt : BossStateMachine
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        currentKissyState = KissyState.Hurt;
        controller.OnDamageable = true;
        CheckedDirection();
    }

    private float _defaultStateTime = 2f;

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;
        if ( elapsedTime >= _defaultStateTime )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_Hurt, KissyfaceAnimeHash.s_Recover );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
