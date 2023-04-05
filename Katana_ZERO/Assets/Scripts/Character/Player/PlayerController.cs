using UnityEngine;

public class PlayerController : Character
{
    private PlayerInput _input;
    private PlayerData _data;
    private Rigidbody2D _rigid;

    public Transform CursorPosition;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _data = GetComponent<PlayerData>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckedSurroundings();
    }

    private void Update()
    {
        CheckedFlip();
        CursorSpritePosition();
    }

    public void HorizontalMovement()
    {
        _rigid.velocity = _data.moveVec;
    }

    private float _jumpHorizontalHelperPower = 1.35f;
    public void Jump()
    {
        _rigid.velocity = new Vector2( _data.moveVec.x, _data.jumpPower );
    }

    private void CursorSpritePosition()
    {
        CursorPosition.position = _input.MouseWorldPos;
    }
   

    private void CheckedFlip()
    {
        if (_data.FlipIsRight && _input.primitiveMoveVec.x < 0 )
        {
            Flip();
        }
        else if ( _data.FlipIsRight == false && _input.primitiveMoveVec.x > 0 )
        {
            Flip();
        }
    }

    public void Flip()
    {
        _data.facingDirection *= -1;
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

 