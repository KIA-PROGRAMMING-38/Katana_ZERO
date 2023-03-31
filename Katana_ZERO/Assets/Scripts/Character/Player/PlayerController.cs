using UnityEngine;

class PlayerController : Character
{
    private PlayerInput _input;
    private Animator _anim;
    private Rigidbody2D _rigid;

    [SerializeField][Range(1f, 100f)] private float _moveSpeed;

    public Vector2 moveVec;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVec = _input.primitiveVec * _moveSpeed;
    }
}

 