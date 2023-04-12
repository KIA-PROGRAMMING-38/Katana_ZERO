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

    private void FixedUpdate()
    {
        Collider2D[] collision  = Physics2D.OverlapCircleAll
            ( _collisionPos.position, _data.AttackRadius, LayerMask.GetMask( "Enemy" ) );

        foreach ( Collider2D elem in collision )
        {
            if ( elem != null ) 
            {
                if ( elem.gameObject.layer == 8 )
                {
                    elem.transform.root.SendMessage( "OnDamaged" );
                }
            }
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
