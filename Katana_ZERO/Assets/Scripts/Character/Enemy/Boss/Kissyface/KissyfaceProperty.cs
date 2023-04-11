using UnityEngine;
using StringLiteral;

public class KissyfaceProperty : MonoBehaviour
{
    private Animator _animator;
    private BossEnemyController _controller;
    private InvokeAnimation _invokeAnim;

    // �� ������ �� ��ü �ʱ�ȭ
    private int _compareToState = int.MaxValue;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<BossEnemyController>();
        _invokeAnim = GetComponent<InvokeAnimation>();
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
            case KissyState.StateThrowAxe:
                return KissyfaceAnimeHash.s_THROW;

            case KissyState.StateJumpAttack:
                return KissyfaceAnimeHash.s_PRELUNGE;

            case KissyState.StateJumpSwing:
                return KissyfaceAnimeHash.s_PREJUMP;

            case KissyState.StateSlash:
                return KissyfaceAnimeHash.s_SLASH;
        }

        return 0;
    }
}