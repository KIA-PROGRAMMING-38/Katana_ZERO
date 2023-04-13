using UnityEngine;

public class AxeController : MonoBehaviour
{
    [SerializeField]
    private GameObject _axeBody;

    private KissyfaceProperty _property;
    private KissyfaceController _controller;
    private Vector3 _targetPos;
    private Vector3 _captureKissyPos;

    [SerializeField]
    [Range(2f, 20f)]
    private float _rotationSpeed;
    [SerializeField]
    [Range( 2f, 20f )]
    private float _jumpRotationSpeed;
    [SerializeField]
    [Range( 2f, 20f )]
    private float _throwRotationSpeed;
    [SerializeField]
    [Range( 2f, 20f )]
    private float _throwAxeSpeed;
    [SerializeField]
    [Range(0f, 2f)]
    private float _offSetX;

    private void Awake()
    {
        _controller = gameObject.transform.root.GetComponent<KissyfaceController>();
        _property = gameObject.transform.root.GetComponent<KissyfaceProperty>();
    }

    private float _valueY;
    private void OnEnable()
    {
        transform.localPosition = Vector3.zero;

        _captureKissyPos = _controller.gameObject.transform.position;
        _valueY = _controller.gameObject.transform.position.y;

        if ( _property.IsJumping )
        {
            _axeBody.transform.position = new Vector3
                ( transform.position.x + _offSetX, transform.position.y, transform.position.z );
        }
        else if ( _property.IsThrow )
        {
            _targetPos = new Vector3
            ( _controller.TargetTransform.position.x, _valueY, _controller.TargetTransform.position.z );
        }
    }

    private void OnDisable()
    {
        _axeBody.transform.localPosition = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }

    private Vector3 _forwardVec = Vector3.forward;

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        if ( _property.IsJumping )
        {
            transform.position = _captureKissyPos;
            _axeBody.transform.Rotate( _forwardVec, _jumpRotationSpeed );
            transform.Rotate( _forwardVec, -_rotationSpeed );
        }
        else if ( _property.IsThrow )
        {
            _axeBody.transform.Rotate( _forwardVec, -_throwRotationSpeed );
            Vector3 curVec = new Vector3( transform.position.x, _valueY, transform.position.z );

            if ( (Vector3.Distance(transform.position, _targetPos)) <= 0.2f )
            {
                _property.IsEjection = false;
            }

            if ( _property.IsEjection )
            {
                transform.position = Vector3.MoveTowards
                    ( curVec, _targetPos, _throwAxeSpeed * deltaTime );
            }
            else
            {
                transform.position = Vector3.MoveTowards
                    ( curVec, _captureKissyPos, _throwAxeSpeed * deltaTime );
            }
        }
    }

    public void JumpSwing()
    {
        _property.IsJumping = true;
    }

    public void ThrowAxe()
    {
        _property.IsThrow = false;
    }
}