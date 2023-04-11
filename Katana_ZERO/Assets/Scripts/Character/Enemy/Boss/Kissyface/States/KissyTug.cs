using StringLiteral;
using UnityEngine;

public class KissyTug : BossStateMachine
{
    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        controller.PrevState = KissyfaceAnimeHash.s_TUG;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        elapsedTime += Time.deltaTime;

        if ( elapsedTime >= 3f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_TUG, KissyfaceAnimeHash.s_RETURNAXE );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
