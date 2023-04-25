using LiteralRepository;
using UnityEngine;
using static KissyfaceAnimInvoker;

public class KissyJumpSwing : BossStateMachine
{
    private Vector2 capturePos;

    override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        capturePos = new Vector2(rigid.velocity.x, rigid.velocity.y - 5f);
        currentKissyState = KissyState.JumpSwing;
        controller.PrevState = (int)KissyState.JumpSwing;
    }

    private float _jumpingTime = 1f;

    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        rigid.velocity = capturePos;

        elapsedTime += Time.deltaTime;
        if ( elapsedTime >= _jumpingTime )
        {
            ChangeState( animator, KissyfaceAnimeHash.s_JumpSwing, KissyfaceAnimeHash.s_LandAttack );
        }
    }

    override public void OnStateExit( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
    {
        base.OnStateExit( animator, stateInfo, layerIndex );

        controller.IsJumping = false;
        controller.Weapon.SetActive( false );
    }
}
