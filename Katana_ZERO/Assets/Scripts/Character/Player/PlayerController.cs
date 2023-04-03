using UnityEngine;

public class PlayerController : Character
{
    private PlayerInput _input;
    private PlayerData _data;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _data = GetComponent<PlayerData>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckedGround();
    }

    private void Update()
    {
        CheckedFlip();
    }

    public void HorizontalMovement()
    {
        _rigid.velocity = _data.moveVec;
    }

    private float _jumpHorizontalHelperPower = 1.35f;
    public void Jump()
    {
        _rigid.velocity = new Vector2( _rigid.velocity.x * _jumpHorizontalHelperPower, _data.jumpPower );
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

    private void Flip()
    {
        _data.FlipIsRight = !_data.FlipIsRight;
        transform.Rotate( 0f, 180f, 0f );
    }

    private void CheckedGround()
    {
        _data.isGrounded = Physics2D.OverlapCircle( _data.groundCheck.position, _data.groundCheckRadius, LayerMask.GetMask( "Ground" ) );
    }

 
}

 