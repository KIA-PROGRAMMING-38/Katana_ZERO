using LiteralRepository;
using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyStruggle : BossStateMachine
{
    private int _count;
    private int _recoverCount = 3;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _count = 3;
        controller.TargetGameObject.gameObject.SetActive( false );
        controller.OnDamageable = true;
        currentKissyState = KissyState.Struggle;
        controller.PrevState = (int)KissyState.Struggle;
        CheckedDirection();
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        controller.TargetGameObject.transform.position = controller.TargetGameObject.transform.position;

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            --_count;
            Debug.Log( $"남은 클릭횟수 : {_count}" );
        }

        if ( _count == 0 )
        {
            --_recoverCount;
            Debug.Log( _recoverCount );

            if ( _recoverCount == 0 )
            {
                ChangeState( animator, KissyfaceAnimeHash.s_Struggle, KissyfaceAnimeHash.s_Die );
            }
            else
            {
                ChangeState( animator, KissyfaceAnimeHash.s_Struggle, KissyfaceAnimeHash.s_Recover );
                controller.TargetGameObject.gameObject.SetActive( true );
            }
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
    }
}
