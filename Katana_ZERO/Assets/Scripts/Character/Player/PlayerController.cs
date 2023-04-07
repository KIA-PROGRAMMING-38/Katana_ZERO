using UnityEngine;

public class PlayerController : Character
{
    private PlayerInput _input;
    private PlayerData _data;
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;

    public Transform CursorPosition;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _data = GetComponent<PlayerData>();
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        CheckedSurroundings();
        CheckedFlip();
    }

    private void Update()
    {
        CursorSpritePosition();
    }

    public void HorizontalMovement()
    {
        _rigid.velocity = _data.MoveVec;
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
        if ( _data.FlipIsRight && _rigid.velocity.x < 0f  )
        {
            Flip();
        }
        else if ( _data.FlipIsRight == false && _rigid.velocity.x > 0f  )
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
}

 