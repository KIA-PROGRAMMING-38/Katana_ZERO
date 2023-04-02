using UnityEngine;

class PlayerController : Character
{
    private PlayerInput _input;
    private Rigidbody2D _rigid;
    private Animator _animator;

    [SerializeField][Range(1f, 100f)] private float _moveSpeed;
    [SerializeField][Range(1f, 100f)] private float _jumpPower;

    public Vector2 moveVec;
    public Vector2 jumpVec;

    public bool onGround;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        jumpVec = _input.primitiveJumpVec * _jumpPower;

        moveVec = new Vector2(_input.primitiveMoveVec.x * _moveSpeed, _rigid.velocity.y );
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if ( collision.gameObject.CompareTag( "Floor" ) )
        {
            onGround = true;
            _animator.SetTrigger( "isReturn" );
        }
    }

}

 