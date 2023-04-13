using LiteralRepository;
using UnityEngine;

public class KissyStruggle : BossStateMachine
{
    private int _count;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _count = 3;
        controller.TargetGameObject.gameObject.SetActive( false );
        controller.PrevState = KissyfaceAnimeHash.s_Struggle;
        CheckedDirection();
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        controller.TargetGameObject.transform.position = controller.TargetGameObject.transform.position;

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            --_count;
        }

        if ( _count == 3 )
        {
            SetTrigger( animator, KissyfaceAnimeHash.s_Struggle, KissyfaceAnimeHash.s_Die );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
