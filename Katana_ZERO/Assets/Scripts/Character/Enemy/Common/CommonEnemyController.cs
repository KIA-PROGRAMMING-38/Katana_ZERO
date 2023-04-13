using LiteralRepository;
using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CommonEnemyController : Enemy
{
    public event Action<bool> CheckedOnDamage;
    public event Action ReadyToAttack;
    public event Action RestoreCondition;

    [Header( "Speed" )]
    public float walkSpeed;
    public float runSpeed;

    [Header( "Patrol" )]
    public float patrolMaxSec;
    public float patrolMinSec;

    // 순회할 포인트 저장
    public Transform[] PatrolPoints;

    [Header( "Idle" )]
    public float idleMaxSec;
    public float idleMinSec;

    [Header( "Attack" )]
    public float attackCooltime;
    public bool isShot;

    [Header( "Common Controller" )]
    public bool TrackActive;
    public bool AttackActive;

    public CommonEnemyType ThisEnemyType;

    public override void Awake()
    {
        base.Awake();
    }

    public virtual void Update()
    {
        CheckedFlip();
    }

    private void CheckedFlip()
    {
        if ( FlipIsRight && rigid.velocity.x < 0f )
        {
            Flip();
        }
        else if ( FlipIsRight == false && rigid.velocity.x > 0f )
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1f;
        FlipIsRight = !FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }

    public override void OnDamaged()
    {
        CheckedOnDamage?.Invoke( OnDamageable );
    }

    public void GunReadyToAttack()
    {
        ReadyToAttack?.Invoke();
    }

    public void GunRestoreCondition()
    {
        RestoreCondition?.Invoke();
    }
}
