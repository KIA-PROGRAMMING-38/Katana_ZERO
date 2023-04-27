using LiteralRepository;
using UnityEngine;
using UnityEngine.Pool;
using Util;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(10f, 100f)]
    public float _bulletSpeed = 10f;
    private Rigidbody2D _rigid;

    private IObjectPool<Bullet> _pool;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigid.velocity = transform.right * _bulletSpeed;
    }

    public void SetPoolReference( IObjectPool<Bullet> pool ) => _pool = pool;
    public void Release() => _pool.Release( this );


    private void OnTriggerEnter2D( Collider2D collision )
    {
        // 바닥 혹은 플레이어와 맞닿았을 시 풀에 다시 집어넣어 줌
        if ( collision.CompareTag( TagLiteral.GROUND )  )
        {
            Release();
        }

        if ( collision.CompareTag( TagLiteral.PLAYER ))
        {
            Release();

            GlobalData.PlayerGameObject.GetComponent<PlayerController>().OnDamaged( gameObject.transform.position );
        }

        // 플레이어에 의해 반사되는 총알일 경우에만 에너미에게 타격을 줄 수 있도록 설계
        if ( gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            if ( collision.CompareTag( TagLiteral.ENEMY ) )
            {
                // 에너미가 총알에 맞을 경우, OutsideEffect 실행
                collision.GetComponent<CommonEnemyController>().LinearEffectController.PlayEffect(collision.transform);

                Release();
            }
        }

        // 플레이어에게 향하는 총알을 플레이어가 튕겨낼 경우, 총알은 튕겨낸 방향으로 되돌아간다
        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) )
        {
            Reflection( collision );
        }
     }

    private void Reflection( Collider2D collision )
    {
        // 반사되는 총알은 레이어를 변경
        gameObject.layer = LayerMaskNumber.s_ReflectedBullet;

        Vector2 normal = collision.transform.right * -1f;
        Vector2 reflectedDirection = Vector2.Reflect( _rigid.velocity.normalized, normal );
        _rigid.velocity = reflectedDirection * _bulletSpeed;

        float reflectAngle = Mathf.Atan2
        ( reflectedDirection.y, reflectedDirection.x ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( 0f, 0f, reflectAngle );
    }
}
