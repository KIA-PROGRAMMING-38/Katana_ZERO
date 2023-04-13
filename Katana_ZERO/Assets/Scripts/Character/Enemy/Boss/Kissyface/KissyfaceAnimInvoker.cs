using UnityEngine;
using LiteralRepository;

public static class KissyDefaultAttackState
{
    public const int StateThrowAxe = 0;
    public const int StateJumpAttack = 1;
    public const int StateJumpSwing = 2;
    public const int StateSlash = 3; 
}

public class KissyfaceAnimInvoker : AnimationManager
{
    [SerializeField]
    private GameObject _setActiveAttack;
    private Animator _animator;
    private BossEnemyController _controller;
    private KissyfaceProperty _property;

    public enum KissyState
    {
        ToBattle = 0,
        Idle = 1,
        PreLunge = 2,
        Lunge = 3,
        LungeAttack = 4,
        Throw = 5,
        Tug = 6,
        ReturnAxe = 7,
        Slash = 8,
        PreJump = 9,
        Jump = 10,
        JumpSwing = 11,
        LandAttack = 12,
        Hurt = 13,
        Struggle = 14,
        Recover = 15,
        Die = 16,
        Block = 17
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = transform.root.GetComponent<BossEnemyController>();
        _property = transform.root.GetComponent<KissyfaceProperty>();
    }

    public override void SetNextAnimation( int state )
    {
        int nextStateHashCode = GetAnimationStateHash( state );

        _animator.SetBool( _controller.PrevState, false );
        _animator.SetBool( nextStateHashCode, true );
    }

    public override void SetNextAnimation()
    {
        _animator.SetBool( _controller.PrevState, false );
        _animator.SetTrigger( KissyfaceAnimeHash.s_Block );
    }

    public override int GetAnimationStateHash( int state )
    {
        switch ( state )
        {
            case (int)KissyState.ToBattle:
                return KissyfaceAnimeHash.s_ToBattle;

            case (int)KissyState.Idle:
                return KissyfaceAnimeHash.s_Idle;

            case (int)KissyState.PreLunge:
                return KissyfaceAnimeHash.s_PreLunge;

            case (int)KissyState.Lunge:
                return KissyfaceAnimeHash.s_Lunge ;

            case (int)KissyState.LungeAttack:
                return KissyfaceAnimeHash.s_LungeAttack;

            case (int)KissyState.Throw:
                return KissyfaceAnimeHash.s_Throw;

            case (int)KissyState.Tug:
                return KissyfaceAnimeHash.s_Tug;

            case (int)KissyState.ReturnAxe:
                return KissyfaceAnimeHash.s_ReturnAxe;

            case (int)KissyState.Slash:
                return KissyfaceAnimeHash.s_Slash;

            case (int)KissyState.PreJump:
                return KissyfaceAnimeHash.s_PreJump;

            case (int)KissyState.Jump:
                return KissyfaceAnimeHash.s_Jump;

            case (int)KissyState.JumpSwing:
                return KissyfaceAnimeHash.s_JumpSwing;

            case (int)KissyState.LandAttack:
                return KissyfaceAnimeHash.s_LandAttack;

            case (int)KissyState.Hurt:
                return KissyfaceAnimeHash.s_Hurt;

            case (int)KissyState.Struggle:
                return KissyfaceAnimeHash.s_Struggle;

            case (int)KissyState.Recover:
                return KissyfaceAnimeHash.s_Recover;

            case (int)KissyState.Die:
                return KissyfaceAnimeHash.s_Die;

            case (int)KissyState.Block:
                return KissyfaceAnimeHash.s_Block;
        }

        return 0;
    }

    public override void ActiveAttack()
    {
        _setActiveAttack.SetActive(true);
    }

    public override void InActiveAttack()
    {
        _setActiveAttack.SetActive(false);
    }

    public override void InvokeThrow()
    {
        _property.IsThrow = true;
        _property.IsEjection = true;
        _property.Weapon.SetActive( true );
    }

    public override void InvokeSwing()
    {
        _property.IsJumping = true;
        _property.Weapon.SetActive( true );
    }
}
