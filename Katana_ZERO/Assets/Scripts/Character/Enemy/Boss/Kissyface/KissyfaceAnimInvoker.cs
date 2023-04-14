using UnityEngine;
using LiteralRepository;
using Unity.VisualScripting;


public class KissyfaceAnimInvoker : AnimationManager
{
    [SerializeField]
    private GameObject _setActiveAttack;
    private Animator _animator;
    private KissyfaceController _controller;

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
        Block = 17,
        Dead = 18,
        NoHead = 19,
        Default = 20
    }
    public enum RandomState
    {
        StateThrowAxe = 0,
        StateJumpAttack = 1,
        StateJumpSwing = 2,
        StateSlash = 3,
        DefaultValue = 4

    }

    public static KissyState currentKissyState;
    public static RandomState nextKissyState = RandomState.DefaultValue;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = transform.root.GetComponent<KissyfaceController>();
    }

    private void Start()
    {
        _controller.SetNextBehaviour -= OnDamagedNextAnimation;
        _controller.SetNextBehaviour += OnDamagedNextAnimation;
    }

    public int RandomNextAttackBehaviour( int nextStateIndex )
    {
        switch ( nextStateIndex )
        {
            case (int)RandomState.StateThrowAxe:
                return KissyfaceAnimeHash.s_Throw;

            case (int)RandomState.StateJumpAttack:
                return KissyfaceAnimeHash.s_PreLunge;

            case (int)RandomState.StateJumpSwing:
                return KissyfaceAnimeHash.s_PreJump;

            case (int)RandomState.StateSlash:
                return KissyfaceAnimeHash.s_Slash;
        }

        return 0;
    }

    public int NextBehaviour()
    {
        while ( true )
        {
            int nextStateIndex = Random.Range( 0, 4 );

            if ( (int)nextKissyState != nextStateIndex )
            {
                nextKissyState = (RandomState)nextStateIndex;
                return RandomNextAttackBehaviour( nextStateIndex );
            }
        }
    }

    public int NextBehaviour( int stateIndex )
    {
        return RandomNextAttackBehaviour( stateIndex );
    }

    private void OnDamagedNextAnimation( bool onDamageable )
    {
        if ( onDamageable == false )
        {
            PlayerBlockAnimation();
        }
        else
        {
            if ( currentKissyState == KissyState.Tug )
            {
                SetNextAnimation( (int)KissyState.Hurt );
            }
            else if ( currentKissyState == KissyState.Hurt )
            {
                SetNextAnimation( (int)KissyState.Struggle );
            }
            else if ( currentKissyState == KissyState.Dead )
            {
                SetAnimationTrigger( KissyfaceAnimeLiteral.NOHEAD );
            }
        }
    }

    public override void SetNextAnimation( int state )
    {
        int prevStateHashCode = GetAnimationStateHash( _controller.PrevState );
        int nextStateHashCode = GetAnimationStateHash( state );

        _animator.SetBool( prevStateHashCode, false );
        _animator.SetBool( nextStateHashCode, true );
    }
    
    private void SetAnimationTrigger( string state )
    {
        int prevStateHashCode = GetAnimationStateHash( _controller.PrevState );

        _animator.SetBool( prevStateHashCode, false );
        _animator.SetTrigger( state );
    }

    private void PlayerBlockAnimation()
    {
        int prevStateHashCode = GetAnimationStateHash( _controller.PrevState );
        
        _animator.SetBool( prevStateHashCode, false );
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

            case (int)KissyState.Dead:
                return KissyfaceAnimeHash.s_Dead;

            case (int)KissyState.NoHead:
                return KissyfaceAnimeHash.s_Dead;
        }

        return 0;
    }

    #region 애니메이션 이벤트 호출 함수
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
        _controller.IsThrow = true;
        _controller.IsEjection = true;
        _controller.Weapon.SetActive( true );
    }

    public override void InvokeSwing()
    {
        _controller.IsJumping = true;
        _controller.Weapon.SetActive( true );
    }
    #endregion
}
