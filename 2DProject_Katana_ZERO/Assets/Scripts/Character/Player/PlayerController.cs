using LiteralRepository;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Util;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : Character
{
    public event Action OnIllusionEffect;

    public GameObject Illusion;
    public GameObject EffectManager;
    private EffectManager _effectManager;

    public GameObject FootParticle;
    public GameObject WallParticle;
    public GameObject DamageSensor;


    [SerializeField]
    public DrawBlood DrawBlood;
    [SerializeField]
    public ImpactBlood ImpactBlood;

    [SerializeField]
    [Range( 0f, 1f )]
    private float _delayLaserDeathTime;

    private PlayerInput _input;
    private PlayerData _data;
    private PlayerAnimInvoker _animInvoker;
    private PlayerAudio _audio;
    private Rigidbody2D _rigid;
    private CapsuleCollider2D _capsule;

    public Transform CursorPosition;
    public event Action<bool> ExistAroundItem;
    public event Action AlreadyHaveItem;

    private IEnumerator _delayDeathEffectCoroutine;

    private WaitForSeconds _delayLaserDeathEffectTime;

    [SerializeField]
    [Range( 0f, 100f )]
    private float _pushedBackPos;

    [Range( 0f, 10f )]
    public float slopeForce;
    [Range( -10f, 10f )]
    public float emptyForce;
    [Range( -10f, 0f )]
    public float downVelocityForce;

    public float slopeForceRayLength;
    public RaycastHit2D belowHit;
    public RaycastHit2D forwardHit;
    public bool IsClimb;

    [SerializeField]
    [Range( 0f, 1f )]
    private float offsetX;
    private Vector3 offsetVec;

    [SerializeField]
    [Range( 0f, 100f )]
    public float slopeRollForce;
    [Range( 0f, 30f )]
    public float downRollVelocityForce;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _data = GetComponent<PlayerData>();
        _rigid = GetComponent<Rigidbody2D>();
        _capsule = GetComponent<CapsuleCollider2D>();
        _animInvoker = GetComponent<PlayerAnimInvoker>();
        _audio = GetComponent<PlayerAudio>();
        _effectManager = EffectManager.GetComponent<EffectManager>();
        _delayLaserDeathEffectTime = new WaitForSeconds( _delayLaserDeathTime );
    }

    private void FixedUpdate()
    {
        CheckedSurroundings();
        GroundStateCheck();
        CheckedFlip();

        UseItem();
    }

    /// <summary>
    /// 플레이어가 밟고 잇는 땅의 타입이 Flat인 경우 Movement
    /// </summary>
    public void FlatGroundMovement()
    {
        _rigid.velocity = new Vector2( _data.MoveVec.x, 0f );
    }

    /// <summary>
    /// 플레이어가 밟고 있는 땅의 타입이 Slope인 경우 Movement
    /// </summary>
    public void SlopeGroundMovement()
    {
        if ( IsClimb )
        {
            Vector2 slopeDirection = Vector2.Perpendicular( belowHit.normal ).normalized;
            Vector2 slopeMovement = new Vector2
                ( slopeDirection.x * -_input.PrimitiveMoveVec.x * slopeForce, 0f );

            _data.MoveVec += slopeMovement;
            _rigid.velocity = new Vector2( _data.MoveVec.x, 0f );
        }
        else
        {
            Vector2 slopeDirection = Vector2.Perpendicular( belowHit.normal ).normalized;
            Vector2 slopeMovement = new Vector2
                ( slopeDirection.x * -_input.PrimitiveMoveVec.x * emptyForce, 0f );

            _data.MoveVec += slopeMovement;
            _rigid.velocity = new Vector2( _data.MoveVec.x, _rigid.velocity.y - downVelocityForce * Time.fixedDeltaTime );
        }
    }

 

    /// <summary>
    /// 플레이어 점프
    /// </summary>
    public void Jump()
    {
        _rigid.velocity = new Vector2( _data.MoveVec.x * 1.5f, _data.jumpPower );
    }


    /// <summary>
    /// 플레이어의 flip 체크
    /// 플레이어가 죽지 않는 이상 입력되는 값에 의해 flip 변경
    /// </summary>
    private void CheckedFlip()
    {
        // 플레이어가 사망한 상태가 아닐 때만 판단
        if ( gameObject.layer != LayerMaskNumber.s_DiePlayer )
        {
            // 오른쪽을 보다가 왼쪽을 보는 경우
            if ( _data.FlipIsRight && _input.PrimitiveMoveVec.x < 0f && _data.OnGround )
            {
                Flip();
            }
            // 왼쪽을 보다가 오른쪽을 보는 경우
            else if ( _data.FlipIsRight == false && _input.PrimitiveMoveVec.x > 0f && _data.OnGround )
            {
                Flip();
            }
        }
    }

    /// <summary>
    /// 플레이어의 JumpFlip 체크
    /// </summary>
    public void CheckedJumpFlip()
    {
        if ( _data.FlipIsRight && _rigid.velocity.x < 0f )
        {
            Flip();
        }
        else if ( _data.FlipIsRight == false && _rigid.velocity.x > 0f )
        {
            Flip();
        }
    }

    /// <summary>
    /// 특정한 조건을 만족할 경우 Flip 실행
    /// 핼퍼 함수의 역할
    /// FacingDirection으로 벡터의 x값 접근 가능
    /// Rotate를 통해 각종 컴포넌트 좌우 반전
    /// </summary>
    public void Flip()
    {
        _data.FacingDirection *= -1;
        _data.FlipIsRight = !_data.FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }


    /// <summary>
    /// 플레이어가 땅 위에서 움직일 경우만 검사한다
    /// Ground의 레이어를 검사하여 값을 플레이어의 PlayerOnGround에 할당한다
    /// </summary>
    private void GroundStateCheck()
    {
        if ( _rigid.velocity.x != 0 )
        {
            offsetVec = new Vector3( offsetX * _data.FacingDirection, 0f, 0f );

            // Ground의 레이어를 검사하는 Raycast 실행
            belowHit = Physics2D.Raycast( transform.position + offsetVec, Vector2.down, slopeForceRayLength,
                ( 1 << LayerMaskNumber.s_FlatGround ) | ( 1 << LayerMaskNumber.s_SlopeGround ) | ( 1 << LayerMaskNumber.s_OneWayGround ) );

            Debug.DrawRay( transform.position + offsetVec, Vector2.down * 2f, Color.red );

            if ( belowHit.transform != null )
            {
                // 검출된 레이어가 Flat인 경우
                if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_FlatGround )
                {
                    // 플레이어가 밟고있는 GroundState == Flat
                    _data.PlayerOnGround = GlobalData.GroundState.Flat;
                }
                // 검출된 레이어가 Slope인 경우
                else if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_SlopeGround )
                {
                    // 플레이어가 밟고있는 GroundState == Slope
                    _data.PlayerOnGround = GlobalData.GroundState.Slope;
                    forwardHit = Physics2D.Raycast
                        ( transform.position, transform.right, slopeForceRayLength, 1 << LayerMaskNumber.s_SlopeGround );

                    // forwardHit 가 true인 경우, Slope를 올라가는 중
                    // forwardHit 가 false인 경우, Slope를 내려가는 중
                    IsClimb = forwardHit;
                    Debug.DrawRay( transform.position, transform.right * 2f, Color.red );
                }
                else if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_OneWayGround )
                {
                    // 플레이어가 밟고있는 GroundState == OneWay
                    _data.PlayerOnGround = GlobalData.GroundState.OneWay;
                }
            }
            else
            {
                _data.PlayerOnGround = GlobalData.GroundState.Empty;
            }
        }
        else if ( Mathf.Abs( _input.PrimitiveMoveVec.x ) > 0.01f && !_data.OnGround )
        {
            // 값이 입력되고 있지만, 땅이 아닐경우 플레이어는 공중에 뜬 상태
            _data.PlayerOnGround = GlobalData.GroundState.Empty;
        }
    }

    /// <summary>
    /// 플레이어의 바닥 검사
    /// 플레이어가 벽에 붙어 있는지, 플레이어가 바닥에 붙어 있는지
    /// </summary>
    private void CheckedSurroundings()
    {
        CheckedGround();
        CheckedWall();
    }

    /// <summary>
    /// 플레이어가 바닥에 붙어있을 경우
    /// GroundCheck 오브젝트가 Ground를 찾을 경우 OnGround == true
    /// </summary>
    private void CheckedGround()
    {
        // 바닥의 GroundCheck에 FlatGround 혹은 SlopeGround가 검출될 경우 그라운드 위에 있는 상태
        _data.OnGround = Physics2D.OverlapCircle( _data.GroundCheck.position, _data.GroundCheckRadius,
            ( 1 << LayerMaskNumber.s_FlatGround ) | ( 1 << LayerMaskNumber.s_SlopeGround ) | ( 1 << LayerMaskNumber.s_OneWayGround ) );
    }

    /// <summary>
    /// 플레이어가 벽에 붙어있을 경우
    /// WallCheck 오브젝트가 Wall을 찾을 경우 IsTouchingWall == true
    /// </summary>
    private void CheckedWall()
    {
        _data.IsTouchingWall = Physics2D.Raycast
            ( _data.WallCheck.position, transform.right, _data.WallCheckDistance, 1 << LayerMaskNumber.s_FlatGround );
    }

    /// <summary>
    /// 지금 벽에 붙어서 액션을 실행하고 있는지 검사
    /// </summary>
    public void CheckedIfWallSliding()
    {
        if ( _data.IsTouchingWall && !_data.OnGround && _rigid.velocity.y < 0 )
        {
            _data.IsWallSliding = true;
        }
        else
        {
            _data.IsWallSliding = false;
        }
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.ITEM ) )
        {
            ExistAroundItem?.Invoke( true );
            GameObject arounditem = collision.gameObject;
            Item item = arounditem.GetComponent<Item>();

            if ( Input.GetMouseButtonDown( 1 ) )
            {
                if ( _data.HasItem )
                {
                    ThrowItem();
                }

                AlreadyHaveItem?.Invoke();
                _data.HasItem = true;
                _data.Item = collision.gameObject;
                collision.gameObject.SetActive( false );
            }
        }
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.ITEM ) )
        {
            ExistAroundItem?.Invoke( false );
        }
    }

    public void UseItem()
    {
        if ( _data.HasItem )
        {
            if ( Input.GetMouseButton( 1 ) )
            {
                ThrowItem();
            }
        }
    }

    private void ThrowItem()
    {
        GameObject throwItem = _data.Item;
        Rigidbody2D itemRigid = throwItem.GetComponent<Rigidbody2D>();
        Item Item = throwItem.GetComponent<Item>();
        throwItem.SetActive( true );
        throwItem.transform.position = _data.ThrowPoint.position;
        throwItem.transform.rotation = _data.ThrowPoint.rotation;
        Item.flyingAway = true;
        _data.HasItem = false;
    }

    /// <summary>
    /// 플레이어가 공격받을경우 실행
    /// 에너미의 AttackSensor 스크립트에서 SendMessage 호출
    /// </summary>
    /// <param name="transform"></param>
    public void OnDamaged( Vector2 transform )
    {
        ChangeLayer( gameObject.transform, LayerMaskNumber.s_DiePlayer );
        GameManager.GetGameOverState();

        Vector2 reflectedDirection = (Vector2)transform
            - (Vector2)gameObject.transform.position;
        Vector2 normal = -reflectedDirection.normalized;

        _rigid.AddForce( normal * _pushedBackPos, ForceMode2D.Impulse );
        _audio.PlayEffectSound( 5 );

        _animInvoker.SetAnimationTrigger( PlayerAnimationLiteral.ONDAMAGED );
        DrawBlood.TargetObject.Add( gameObject );
        DrawBlood.StartDrawBlood( DrawBlood.TargetObject.Count - 1 );
    }

    /// <summary>
    /// 플레이어가 특정 액션을 실행할 경우 호출
    /// 현재 Flip, Roll, Attack 상태에 진입할 경우 잔상이 실행된다
    /// </summary>
    public void ActiveAfterImage()
    {
        OnIllusionEffect?.Invoke();
    }

    /// <summary>
    /// 플레이어가 레이저에 피격될 경우 실행 될 이펙트
    /// </summary>
    public void Burn()
    {
        if ( _delayDeathEffectCoroutine != null )
        {
            StopCoroutine( _delayDeathEffectCoroutine );
        }

        _audio.PlayEffectSound( 4 );
        _delayDeathEffectCoroutine = DelayDeathEffect();
        StartCoroutine( _delayDeathEffectCoroutine );
    }

    // 레이저 Material 오브젝트 삽입
    public Material _laser;
    private IEnumerator DelayDeathEffect()
    {
        yield return _delayLaserDeathEffectTime;

        _effectManager.PlayLaserBurnEffect( transform.root, gameObject.GetComponent<SpriteRenderer>() );

        gameObject.SetActive( false );
    }

    public void MoveToDownOnOneWay()
    {
        if ( _changeLayerCoroutine != null )
        {
            StopCoroutine( _changeLayerCoroutine );
        }

        _changeLayerCoroutine = ChangeLayer();
        StartCoroutine( _changeLayerCoroutine );
    }

    private IEnumerator _changeLayerCoroutine;

    private IEnumerator ChangeLayer()
    {
        gameObject.layer = LayerMaskNumber.s_PlayerOneWay;
        _capsule.enabled = false;

        yield return new WaitForSeconds( 0.3f );

        gameObject.layer = LayerMaskNumber.s_Player;
        _capsule.enabled = true;
    }
}