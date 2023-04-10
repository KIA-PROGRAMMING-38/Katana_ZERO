using StringLiteral;
using UnityEngine;

public class KnifeProperty : MonoBehaviour
{
    private Animator _animator;
    private CommonEnemyController _controller;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CommonEnemyController>();
    }

    private void Update()
    {
        if ( _controller.PrevState == EnemyAnimationLiteral.ATTACK )
        {
            _controller.OnDamageable = false;
        }
        else
        {
            _controller.OnDamageable = true;
        }
    }

    private void OnDamaged()
    {
        if ( _controller.OnDamageable )
        {
            _controller.rigid.velocity = Vector2.zero;
            _animator.SetBool( _controller.PrevState, false );
            _animator.SetTrigger( EnemyAnimationHash.s_DIE );
            _controller.ChangeLayer( gameObject.transform, 9 );
        }
        else
        {
            _animator.SetBool( EnemyAnimationHash.s_ATTACK, false );
            _animator.SetBool( EnemyAnimationHash.s_KNOCKDOWN, true );
        }
    }
}
