using StringLiteral;
using UnityEngine;

public class KissyJumpSwing : BossStateMachine
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = KissyfaceAnimeHash.s_JUMPSWING;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;

        if ( elapsedTime >= 3f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_JUMPSWING, KissyfaceAnimeHash.s_LANDATTACK );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
