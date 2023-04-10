using StringLiteral;
using UnityEngine;

public class GunProperty : MonoBehaviour
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

    }

    private void OnDamaged()
    {
        _controller.rigid.velocity = Vector2.zero;
        _animator.SetBool( _controller.PrevState, false );
        _animator.SetTrigger( EnemyAnimationHash.s_DIE );
        _controller.ChangeLayer( gameObject.transform, 9 );
    }
}
