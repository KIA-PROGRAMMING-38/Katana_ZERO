using LiteralRepository;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(3f, 20f)]
    public float _bulletSpeed = 10f;
    private Rigidbody2D _rigid;

    private IObjectPool<Bullet> _managedPool;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private Vector2 _velocity;

    private void Start()
    {
        Initialize();

        _rigid.velocity = _velocity;
    }

    public void SetManagedPool( IObjectPool<Bullet> pool )
    {
        _managedPool = pool;
    }

    private void Initialize()
    {
        _velocity = transform.right * _bulletSpeed;
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        // �ٴ� Ȥ�� �÷��̾�� �´���� �� Ǯ�� �ٽ� ����־� ��
        if ( collision.CompareTag( TagLiteral.FLOOR ) || collision.CompareTag( TagLiteral.PLAYER ) )
        {
            _managedPool.Release( this );
        }

        // �÷��̾ ���� �ݻ�Ǵ� �Ѿ��� ��쿡�� ���ʹ̿��� Ÿ���� �� �� �ֵ��� ����
        if ( gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            if ( collision.CompareTag( TagLiteral.ENEMY ) )
            {
                _managedPool.Release( this );

                // ���ʹ̰� �Ѿ˿� ���� ���, OutsideEffect ����
                collision.GetComponent<CommonEnemyController>().OutsideEffect.ActivateEffect();
            }
        }

        // �÷��̾�� ���ϴ� �Ѿ��� �÷��̾ ƨ�ܳ� ���, �Ѿ��� ƨ�ܳ� �������� �ǵ��ư���
        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) )
        {
            Reflection( collision );
        }
    }

    private void Reflection( Collider2D collision )
    {
        // �ݻ�Ǵ� �Ѿ��� ���̾ ����
        gameObject.layer = LayerMaskNumber.s_ReflectedBullet;

        Vector2 normal = collision.transform.right * -1f;
        Vector2 reflectedDirection = Vector2.Reflect( _rigid.velocity.normalized, normal );
        _rigid.velocity = reflectedDirection * _bulletSpeed;

        float reflectAngle = Mathf.Atan2
        ( reflectedDirection.y, reflectedDirection.x ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( 0f, 0f, reflectAngle );
    }
}
