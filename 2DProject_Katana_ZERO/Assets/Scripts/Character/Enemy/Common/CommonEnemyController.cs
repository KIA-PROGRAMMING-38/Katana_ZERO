using LiteralRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Util;

public class CommonEnemyController : Enemy
{
    public event Action<bool> CheckedOnDamage;
    public event Action ReadyToAttack;
    public event Action RestoreCondition;

    public DrawBlood DrawBlood;
    public ImpactBlood ImpactBlood;
    public LinearEffectController LinearEffectController;

    [Header( "Speed" )]
    public float walkSpeed;
    public float runSpeed;
    public float slopeForce;
    public float emptyForce;
    public float downVelocityForce;

    [Header( "Patrol" )]
    public float patrolMaxSec;
    public float patrolMinSec;
    // ��ȸ�� ����Ʈ ����
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
    public GlobalData.GroundState EnemyOnGround;

    private IEnumerator _delayDeathEffectCoroutine;
    private WaitForSeconds _delayLaserDeathEffectTime;
    [SerializeField]
    private EffectManager _effectManager;
    [SerializeField]
    public Transform BodyTransform;


    public override void Awake()
    {
        base.Awake();

        slopeForceRayLength = 3f;
    }

    private void Start()
    {
        GameManager.SetGameOverEffect -= SetIdleState;
        GameManager.SetGameOverEffect += SetIdleState;
    }

    private void FixedUpdate()
    {
        GroundStateCheck();
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

    private void SetIdleState()
    {
        BodyAnimator.SetBool( PrevState, false );
        BodyAnimator.SetBool( EnemyAnimationHash.s_Idle, true );
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

    [SerializeField]
    [Range( 0f, 1f )]
    private float offsetX;
    private Vector3 offsetVec;
    public RaycastHit2D belowHit;
    public RaycastHit2D forwardHit;
    public float slopeForceRayLength;
    public bool IsClimb;

    private void GroundStateCheck()
    {
        if ( rigid.velocity.x != 0 )
        {
            offsetVec = new Vector3( offsetX * FacingDirection, 0f, 0f );

            // Ground�� ���̾ �˻��ϴ� Raycast ����
            belowHit = Physics2D.Raycast( transform.position + offsetVec, Vector2.down, slopeForceRayLength,
                ( 1 << LayerMaskNumber.s_FlatGround ) | ( 1 << LayerMaskNumber.s_SlopeGround ) | ( 1 << LayerMaskNumber.s_OneWayGround ) );

            Debug.DrawRay( transform.position + offsetVec, Vector2.down * 2f, Color.red );

            if ( belowHit.transform != null )
            {
                // ����� ���̾ Flat�� ���
                if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_FlatGround )
                {
                    // ���ʹ̰� ����ִ� GroundState == Flat
                    EnemyOnGround = GlobalData.GroundState.Flat;
                }
                // ����� ���̾ OneWay�� ���
                else if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_OneWayGround )
                {
                    // ���ʹ̰� ����ִ� GroundState == OneWay
                    EnemyOnGround = GlobalData.GroundState.OneWay;
                }
                // ����� ���̾ Slope�� ���
                else if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_SlopeGround )
                {
                    // ���ʹ̰� ����ִ� GroundState == Slope
                    EnemyOnGround = GlobalData.GroundState.Slope;
                    forwardHit = Physics2D.Raycast
                        ( transform.position, transform.right, slopeForceRayLength, 1 << LayerMaskNumber.s_SlopeGround );

                    // forwardHit �� true�� ���, Slope�� �ö󰡴� ��
                    // forwardHit �� false�� ���, Slope�� �������� ��
                    IsClimb = forwardHit;
                    Debug.DrawRay( transform.position, transform.right * 2f, Color.red );
                }
            }
            else
            {
                EnemyOnGround = GlobalData.GroundState.Empty;
            }
        }
    }

   
    /// <summary>
    /// ���ʹ̰� �������� �ǰݵ� ��� ���� �� ����Ʈ
    /// </summary>
    public void Burn()
    {
        if ( _delayDeathEffectCoroutine != null )
        {
            StopCoroutine( _delayDeathEffectCoroutine );
        }

        _delayDeathEffectCoroutine = DelayDeathEffect();
        StartCoroutine( _delayDeathEffectCoroutine );
    }

    // ������ Material ������Ʈ ����
    public Material _laser;
    private IEnumerator DelayDeathEffect()
    {
        yield return _delayLaserDeathEffectTime;

        _effectManager.PlayLaserBurnEffect
            ( BodyTransform, BodyTransform.gameObject.GetComponent<SpriteRenderer>() );

        gameObject.SetActive( false );
    }
}
