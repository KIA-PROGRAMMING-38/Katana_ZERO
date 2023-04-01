using UnityEngine;

class PlayerController : Character
{
    private PlayerInput _input;
    private Rigidbody2D _rigid;

    [SerializeField][Range(1f, 100f)] private float _moveSpeed;

    public Vector2 moveVec;
    public Vector2 jumpVec;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVec = _input.primitiveMoveVec * ( _moveSpeed );

        _rigid.velocity = moveVec;
    }
}

 