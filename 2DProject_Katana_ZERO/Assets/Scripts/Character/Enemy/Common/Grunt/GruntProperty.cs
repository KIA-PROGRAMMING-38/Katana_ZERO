using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntProperty : MonoBehaviour
{
    private Animator _animator;
    private CommonEnemyController _controller;
    private Rigidbody2D _rigid;

    [SerializeField]
    [Range( 0f, 100f )]
    private float _pushedBackPos;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CommonEnemyController>();
        _rigid = GetComponent<Rigidbody2D>();

        _controller.ThisEnemyType = Enemy.CommonEnemyType.Grunt;
    }

    private void Start()
    {
        _controller.CheckedOnDamage -= DamagedEffect;
        _controller.CheckedOnDamage += DamagedEffect;
    }

    private void DamagedEffect( bool onDamageable )
    {
        _controller.rigid.velocity = Vector2.zero;
        _animator.SetBool( _controller.PrevState, false );
        _animator.SetTrigger( EnemyAnimationHash.s_Die );
        _controller.ChangeLayer( _controller.BodyTransform, LayerMaskNumber.s_DieEnemy );
        _controller.DrawBlood.TargetObject.Add( gameObject );
        _controller.DrawBlood.StartDrawBlood( _controller.DrawBlood.TargetObject.Count - 1 );

        Vector2 reflectedDirection = (Vector2)_controller.ThisIsPlayer.gameObject.transform.position
            - (Vector2)gameObject.transform.position;
        Vector2 normal = -reflectedDirection.normalized;

        _rigid.AddForce( normal  * _pushedBackPos, ForceMode2D.Impulse );
    }
}
