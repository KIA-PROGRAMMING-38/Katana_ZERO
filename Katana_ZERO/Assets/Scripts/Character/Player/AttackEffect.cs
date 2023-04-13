using LiteralRepository;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] private Transform _targetPos;
    [SerializeField] private Transform _collisionPos;
    private PlayerData _data;

    public SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        _data = GetComponentInParent<PlayerData>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (collision.gameObject.layer == LayerMaskNumber.s_ColliderSensor )
        {
            // 화면에서 타격 이펙트 호출
        }
    }

    private void OnEnable()
    {
        if ( _data.CursorDirection.x > 0f )
        {
            transform.localRotation = Quaternion.Euler( 0f, 0f, _data.AttackAngle );
        }
        else
        {
            transform.localRotation = Quaternion.Euler( 180f, 180f, -_data.AttackAngle );
        }
    }
}
