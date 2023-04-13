using LiteralRepository;
using UnityEngine;

public class KissyJumpSwing : BossStateMachine
{
    private Vector2 capturePos;
    private AxeController _axeController;
    private KissyfaceProperty _property;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        _property = animator.transform.root.GetComponent<KissyfaceProperty>();
        _axeController = _property.Weapon.GetComponent<AxeController>();

        capturePos = new Vector2(rigid.velocity.x, rigid.velocity.y - 0.25f);
        controller.PrevState = KissyfaceAnimeHash.s_JumpSwing;
    }

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        rigid.velocity = capturePos;

        elapsedTime += Time.deltaTime;
        if ( elapsedTime >= 1f )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_JumpSwing, KissyfaceAnimeHash.s_LandAttack );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        _property.IsJumping = false;
        _property.Weapon.SetActive( false );
    }
}
