using LiteralRepository;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static KissyfaceAnimInvoker;

public class KissyTug : BossStateMachine
{
    private AxeController _axeController;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
        
        _axeController = controller.Weapon.GetComponent<AxeController>();

        currentKissyState = KissyState.Tug;
        controller.PrevState = (int)KissyState.Tug;
        controller.OnDamageable = true;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( controller.IsEjection == false && ( Vector3.Distance( animator.transform.position, controller.Weapon.transform.position ) ) <= 0.1f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_Tug, KissyfaceAnimeHash.s_ReturnAxe );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        controller.IsThrow = false;
        controller.Weapon.SetActive( false );
    }
}
