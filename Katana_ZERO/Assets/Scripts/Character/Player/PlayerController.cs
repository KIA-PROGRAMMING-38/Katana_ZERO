using LiteralRepository;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Character
{
    public event Action OnIllusionEffect;

    public GameObject Illusion;
    public GameObject EffectManager;
    private EffectManager _effectManager;

    public GameObject FootParticle;
    public GameObject WallParticle;

    [SerializeField]
    [Range( 0f, 1f )]
    private float _delayLaserDeathTime;

    private PlayerInput _input;
    private PlayerData _data;
    private Rigidbody2D _rigid;

    public Transform CursorPosition;
    public event Action<bool> ExistAroundItem;
    public event Action AlreadyHaveItem;

    private IEnumerator _delayDeathEffectCoroutine;
  
    private WaitForSeconds _delayLaserDeathEffectTime;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _data = GetComponent<PlayerData>();
        _rigid = GetComponent<Rigidbody2D>();
        _effectManager = EffectManager.GetComponent<EffectManager>();
        _delayLaserDeathEffectTime = new WaitForSeconds( _delayLaserDeathTime );

    }

    private void FixedUpdate()
    {
        CheckedSurroundings();
        CheckedFlip();

        UseItem();
    }

    private void Update()
    {
        CursorSpritePosition();
    }

    public void HorizontalMovement()
    {
        if ( _data.OnGround )
        {
            _rigid.velocity = new Vector2( _data.MoveVec.x, 0f );
        }
    }

    public void Jump()
    {
        _rigid.velocity = new Vector2( _data.MoveVec.x, _data.jumpPower );
    }

    private void CursorSpritePosition()
    {
        CursorPosition.position = _input.PrimitiveMouseWorldPos;
    }

    private void CheckedFlip()
    {
        if ( _data.FlipIsRight && _rigid.velocity.x < 0f && _data.OnGround )
        {
            Flip();
        }
        else if ( _data.FlipIsRight == false && _rigid.velocity.x > 0f && _data.OnGround )
        {
            Flip();
        }
    }

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

    public void Flip()
    {
        _data.FacingDirection *= -1;
        _data.FlipIsRight = !_data.FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }

    private void CheckedSurroundings()
    {
        CheckedGround();
        CheckedWall();
    }

    private void CheckedGround()
    {
        _data.OnGround = Physics2D.OverlapCircle( _data.GroundCheck.position, _data.GroundCheckRadius, LayerMask.GetMask( "Ground" ) );
    }

    private void CheckedWall()
    {
        _data.IsTouchingWall = Physics2D.Raycast( _data.WallCheck.position, transform.right, _data.WallCheckDistance, LayerMask.GetMask( "Ground" ) );
    }

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

    public override void OnDamaged()
    {
        Debug.Log( "공격당함!" );
    }

    public void ActiveAfterImage()
    {
        OnIllusionEffect?.Invoke();
    }

    public void Burn()
    {
        if ( _delayDeathEffectCoroutine != null )
        {
            StopCoroutine( _delayDeathEffectCoroutine );
        }

        _delayDeathEffectCoroutine = DelayDeathEffect();
        StartCoroutine( _delayDeathEffectCoroutine );
    }

    private IEnumerator DelayDeathEffect()
    {
        yield return _delayLaserDeathEffectTime;

        _effectManager.PlayLaserBurnEffect( transform.root , gameObject.GetComponent<SpriteRenderer>() );
        gameObject.SetActive( false );
    }
}

