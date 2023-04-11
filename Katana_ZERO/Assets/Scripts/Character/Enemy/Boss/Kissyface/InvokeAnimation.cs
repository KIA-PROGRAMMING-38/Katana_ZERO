using UnityEngine;
using StringLiteral;

public static class KissyState
{
    public const int StateThrowAxe = 0;
    public const int StateJumpAttack = 1;
    public const int StateJumpSwing = 2;
    public const int StateSlash = 3;
}

public class InvokeAnimation : MonoBehaviour
{
    private BossEnemyController _controller;
    private KissyfaceProperty _property;
    private Animator _animator;

    private const int _toBattle = 0;
    private const int _idle = 1;
    private const int _preLunge = 2;
    private const int _lunge = 3;
    private const int _lungeAttack = 4;
    private const int _throw = 5;
    private const int _tug = 6;
    private const int _returnAxe = 7;
    private const int _slash = 8;
    private const int _preJump = 9;
    private const int _jump = 10;
    private const int _jumpSwing = 11;
    private const int _landAttack = 12;
    private const int _hurt = 13;
    private const int _struggle = 14;
    private const int _recover = 15;
    private const int _die = 16;

    private void Awake()
    {
        _controller = transform.root.GetComponent<BossEnemyController>();
        _property = transform.root.GetComponent<KissyfaceProperty>();
        _animator = GetComponent<Animator>();
    }

    public void SetNextAnimation( int state )
    {
        int nextStateHashCode = GetAnimationStateHash( state );

        _animator.SetBool( _controller.PrevState, false );
        _animator.SetBool( nextStateHashCode, true );
    }

    private int GetAnimationStateHash( int state )
    {
        switch ( state )
        {
            case _toBattle:
                return KissyfaceAnimeHash.s_TOBATTLE;

            case _idle:
                return KissyfaceAnimeHash.s_IDLE;

            case _preLunge:
                return KissyfaceAnimeHash.s_PRELUNGE;

            case _lunge:
                return KissyfaceAnimeHash.s_LUNGE ;

            case _lungeAttack:
                return KissyfaceAnimeHash.s_LUNGEATTACK;

            case _throw:
                return KissyfaceAnimeHash.s_THROW;

            case _tug:
                return KissyfaceAnimeHash.s_TUG;

            case _returnAxe:
                return KissyfaceAnimeHash.s_RETURNAXE;

            case _slash:
                return KissyfaceAnimeHash.s_SLASH;

            case _preJump:
                return KissyfaceAnimeHash.s_PREJUMP;

            case _jump:
                return KissyfaceAnimeHash.s_JUMP;

            case _jumpSwing:
                return KissyfaceAnimeHash.s_JUMPSWING;

            case _landAttack:
                return KissyfaceAnimeHash.s_LANDATTACK;

            case _hurt:
                return KissyfaceAnimeHash.s_HURT;

            case _struggle:
                return KissyfaceAnimeHash.s_STRUGGLE;

            case _recover:
                return KissyfaceAnimeHash.s_RECOVER;

            case _die:
                return KissyfaceAnimeHash.s_DIE;
        }

        return 0;
    }
}
