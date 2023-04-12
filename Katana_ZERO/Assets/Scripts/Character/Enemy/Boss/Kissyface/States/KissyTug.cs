using LiteralRepository;
using UnityEngine;

public class KissyTug : BossStateMachine
{
    private AxeController _axeController;
    private KissyfaceProperty _property;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );
        
        _property = animator.transform.root.GetComponent<KissyfaceProperty>();
        _axeController = _property.Weapon.GetComponent<AxeController>();

        controller.PrevState = KissyfaceAnimeHash.s_TUG;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( _property.IsEjection == false && ( Vector3.Distance( animator.transform.position, _property.Weapon.transform.position ) ) <= 0.1f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_TUG, KissyfaceAnimeHash.s_RETURNAXE );
            
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        _property.IsThrow = false;
        _property.Weapon.SetActive( false );
    }
}
