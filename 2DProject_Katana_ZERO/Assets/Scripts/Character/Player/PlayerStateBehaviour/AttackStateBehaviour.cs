using UnityEngine;
using LiteralRepository;
using static PlayerAnimInvoker;

public class AttackStateBehaviour : PlayerState
{
    private Vector2 _attackDirection;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter( animator, stateInfo, layerIndex );

        effectManager.OnEnableAttackEffect();

        rigid.velocity = Vector2.zero;
        rigid.gravityScale = 0f;

        data.CapturedCatchDirection = 
            input.PrimitiveMouseWorldPos - (Vector2)animator.transform.position;

        _attackDirection = data.CursorDirection.normalized;

        rigid.AddForce( _attackDirection * data.AttackForce, ForceMode2D.Impulse );
        controller.CheckedJumpFlip();
        controller.ActiveAfterImage();

        audio.PlayEffectSound( EffectSoundRandomPlay() );
        CurrentPlayerState = PlayerAnimInvoker.PlayerState.Attack;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate( animator, stateInfo, layerIndex );

        if ( stateInfo.normalizedTime >= data.AttackAnimElapsedTime )
        {
            if ( data.OnGround )
            {
                ChangeState( animator, PlayerAnimationLiteral.ATTACK, PlayerAnimationLiteral.IDLE );
            }
            else
            {
                ChangeState( animator, PlayerAnimationLiteral.ATTACK, PlayerAnimationLiteral.FALL );
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit( animator, stateInfo, layerIndex );
        effectManager.OnDisableAttackEffect();

        rigid.gravityScale = data.DefaultGravityScale;
        rigid.velocity = new Vector2( 0f , -2f );
    }

    private int EffectSoundRandomPlay()
    {
        int randomPick = Random.Range( 1, 4 );

        return randomPick;
    }
}
