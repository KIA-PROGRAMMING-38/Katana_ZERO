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
        _rigid.velocity = _data.moveVec;
    }

    public void Jump()
    {
        _rigid.velocity = new Vector2( _data.moveVec.x, _data.jumpPower );
    }

    private void CursorSpritePosition()
    {
        CursorPosition.position = _input.PrimitiveMouseWorldPos;
    }

    private void CheckedFlip()
    {
        if ( _data.FlipIsRight && _rigid.velocity.x < 0f && _data.isGrounded )
        {
            Flip();
        }
        else if ( _data.FlipIsRight == false && _rigid.velocity.x > 0f && _data.isGrounded )
        {
            Flip();
        }
    }

    public void CheckedFlip(float checkedDirection)
    {
        if ( checkedDirection > 0f )
        {
            Flip();
        }
        else
        {
            Flip();
        }
    }

    public void Flip()
    {
        _data.facingDirection *= -1;
        _data.FlipIsRight = !_data.FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
        // _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private void CheckedSurroundings()
    {
        CheckedGround();
        CheckedWall();
    }

    private void CheckedGround()
    {
        _data.isGrounded = Physics2D.OverlapCircle( _data.groundCheck.position, _data.groundCheckRadius, LayerMask.GetMask( "Ground" ) );
    }

    private void CheckedWall()
    {
        _data.isTouchingWall = Physics2D.Raycast( _data.wallCheck.position, transform.right, _data.wallCheckDistance, LayerMask.GetMask( "Ground" ) );
    }

    public void CheckedIfWallSliding()
    {
        if ( _data.isTouchingWall && !_data.isGrounded && _rigid.velocity.y < 0 )
        {
            _data.isWallSliding = true;
        }
        else
        {
            _data.isWallSliding = false;
        }
    }
}

 