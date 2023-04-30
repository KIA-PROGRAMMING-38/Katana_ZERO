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
    /// �÷��̾ ��� �մ� ���� Ÿ���� Flat�� ��� Movement
    /// </summary>
    public void FlatGroundMovement()
    {
        _rigid.velocity = new Vector2( _data.MoveVec.x, 0f );
    }

    /// <summary>
    /// �÷��̾ ��� �ִ� ���� Ÿ���� Slope�� ��� Movement
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
    /// �÷��̾� ����
    /// </summary>
    public void Jump()
    {
        _rigid.velocity = new Vector2( _data.MoveVec.x * 1.5f, _data.jumpPower );
    }


    /// <summary>
    /// �÷��̾��� flip üũ
    /// �÷��̾ ���� �ʴ� �̻� �ԷµǴ� ���� ���� flip ����
    /// </summary>
    private void CheckedFlip()
    {
        // �÷��̾ ����� ���°� �ƴ� ���� �Ǵ�
        if ( gameObject.layer != LayerMaskNumber.s_DiePlayer )
        {
            // �������� ���ٰ� ������ ���� ���
            if ( _data.FlipIsRight && _input.PrimitiveMoveVec.x < 0f && _data.OnGround )
            {
                Flip();
            }
            // ������ ���ٰ� �������� ���� ���
            else if ( _data.FlipIsRight == false && _input.PrimitiveMoveVec.x > 0f && _data.OnGround )
            {
                Flip();
            }
        }
    }

    /// <summary>
    /// �÷��̾��� JumpFlip üũ
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
    /// Ư���� ������ ������ ��� Flip ����
    /// ���� �Լ��� ����
    /// FacingDirection���� ������ x�� ���� ����
    /// Rotate�� ���� ���� ������Ʈ �¿� ����
    /// </summary>
    public void Flip()
    {
        _data.FacingDirection *= -1;
        _data.FlipIsRight = !_data.FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }


    /// <summary>
    /// �÷��̾ �� ������ ������ ��츸 �˻��Ѵ�
    /// Ground�� ���̾ �˻��Ͽ� ���� �÷��̾��� PlayerOnGround�� �Ҵ��Ѵ�
    /// </summary>
    private void GroundStateCheck()
    {
        if ( _rigid.velocity.x != 0 )
        {
            offsetVec = new Vector3( offsetX * _data.FacingDirection, 0f, 0f );

            // Ground�� ���̾ �˻��ϴ� Raycast ����
            belowHit = Physics2D.Raycast( transform.position + offsetVec, Vector2.down, slopeForceRayLength,
                ( 1 << LayerMaskNumber.s_FlatGround ) | ( 1 << LayerMaskNumber.s_SlopeGround ) | ( 1 << LayerMaskNumber.s_OneWayGround ) );

            Debug.DrawRay( transform.position + offsetVec, Vector2.down * 2f, Color.red );

            if ( belowHit.transform != null )
            {
                // ����� ���̾ Flat�� ���
                if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_FlatGround )
                {
                    // �÷��̾ ����ִ� GroundState == Flat
                    _data.PlayerOnGround = GlobalData.GroundState.Flat;
                }
                // ����� ���̾ Slope�� ���
                else if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_SlopeGround )
                {
                    // �÷��̾ ����ִ� GroundState == Slope
                    _data.PlayerOnGround = GlobalData.GroundState.Slope;
                    forwardHit = Physics2D.Raycast
                        ( transform.position, transform.right, slopeForceRayLength, 1 << LayerMaskNumber.s_SlopeGround );

                    // forwardHit �� true�� ���, Slope�� �ö󰡴� ��
                    // forwardHit �� false�� ���, Slope�� �������� ��
                    IsClimb = forwardHit;
                    Debug.DrawRay( transform.position, transform.right * 2f, Color.red );
                }
                else if ( belowHit.transform.gameObject.layer == LayerMaskNumber.s_OneWayGround )
                {
                    // �÷��̾ ����ִ� GroundState == OneWay
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
            // ���� �Էµǰ� ������, ���� �ƴҰ�� �÷��̾�� ���߿� �� ����
            _data.PlayerOnGround = GlobalData.GroundState.Empty;
        }
    }

    /// <summary>
    /// �÷��̾��� �ٴ� �˻�
    /// �÷��̾ ���� �پ� �ִ���, �÷��̾ �ٴڿ� �پ� �ִ���
    /// </summary>
    private void CheckedSurroundings()
    {
        CheckedGround();
        CheckedWall();
    }

    /// <summary>
    /// �÷��̾ �ٴڿ� �پ����� ���
    /// GroundCheck ������Ʈ�� Ground�� ã�� ��� OnGround == true
    /// </summary>
    private void CheckedGround()
    {
        // �ٴ��� GroundCheck�� FlatGround Ȥ�� SlopeGround�� ����� ��� �׶��� ���� �ִ� ����
        _data.OnGround = Physics2D.OverlapCircle( _data.GroundCheck.position, _data.GroundCheckRadius,
            ( 1 << LayerMaskNumber.s_FlatGround ) | ( 1 << LayerMaskNumber.s_SlopeGround ) | ( 1 << LayerMaskNumber.s_OneWayGround ) );
    }

    /// <summary>
    /// �÷��̾ ���� �پ����� ���
    /// WallCheck ������Ʈ�� Wall�� ã�� ��� IsTouchingWall == true
    /// </summary>
    private void CheckedWall()
    {
        _data.IsTouchingWall = Physics2D.Raycast
            ( _data.WallCheck.position, transform.right, _data.WallCheckDistance, 1 << LayerMaskNumber.s_FlatGround );
    }

    /// <summary>
    /// ���� ���� �پ �׼��� �����ϰ� �ִ��� �˻�
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
    /// �÷��̾ ���ݹ������ ����
    /// ���ʹ��� AttackSensor ��ũ��Ʈ���� SendMessage ȣ��
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
    /// �÷��̾ Ư�� �׼��� ������ ��� ȣ��
    /// ���� Flip, Roll, Attack ���¿� ������ ��� �ܻ��� ����ȴ�
    /// </summary>
    public void ActiveAfterImage()
    {
        OnIllusionEffect?.Invoke();
    }

    /// <summary>
    /// �÷��̾ �������� �ǰݵ� ��� ���� �� ����Ʈ
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

    // ������ Material ������Ʈ ����
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