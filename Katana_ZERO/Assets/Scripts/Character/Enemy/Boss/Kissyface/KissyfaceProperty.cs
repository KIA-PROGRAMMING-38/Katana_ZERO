using UnityEngine;
using LiteralRepository;
using static KissyfaceAnimInvoker;
using System.Collections;

public class KissyfaceProperty : MonoBehaviour
{
    private Animator _animator;
    private KissyfaceController _controller;
    private KissyfaceAnimInvoker _invokeAnim;

    public GameObject Weapon;

    public bool IsJumping;
    public bool IsThrow;

    // Throw Animation에서 도끼가 사출된 상태
    public bool IsEjection;

    // 신 시작할 때 객체 초기화
    private int _compareToState = int.MaxValue;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<KissyfaceController>();
        _invokeAnim = GetComponentInChildren<KissyfaceAnimInvoker>();
    }

    public int NextBehaviour()
    {
        while ( true )
        {
            int nextStateIndex = Random.Range( 0, 4 );

            if ( _compareToState != nextStateIndex )
            {
                _compareToState = nextStateIndex;
                return CheckedNextState( nextStateIndex );
            }
        }
    }

    public int CheckedNextState( int nextStateIndex )
    {
        switch ( nextStateIndex )
        {
            case KissyDefaultAttackState.StateThrowAxe:
                return KissyfaceAnimeHash.s_Throw;

            case KissyDefaultAttackState.StateJumpAttack:
                return KissyfaceAnimeHash.s_PreLunge;

            case KissyDefaultAttackState.StateJumpSwing:
                return KissyfaceAnimeHash.s_PreJump;

            case KissyDefaultAttackState.StateSlash:
                return KissyfaceAnimeHash.s_Slash;
        }

        return 0;
    }

    private void OnDamaged()
    {
        if ( !_controller.OnDamageable )
        {
            _invokeAnim.SetNextAnimation();
        }
        else if ( _controller.OnDamageable )
        {
            Debug.Log( _controller.OnDamageable );
            Debug.Log( _controller.OnStruggle );

            if ( _controller.OnStruggle )
            {
                _invokeAnim.SetNextAnimation( (int)KissyState.Struggle );
            }
            else
            {
                _invokeAnim.SetNextAnimation( (int)KissyState.Hurt );

                StartCoroutine( OnStruggle() );
            }
        }
    }

    IEnumerator OnStruggle()
    {
        yield return new WaitForSeconds( 0.3f );

        _controller.OnStruggle = true;
    }
}