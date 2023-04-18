using LiteralRepository;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] 
    private Transform _targetPos;
    [SerializeField] 
    private PlayerData _data;
    [SerializeField]
    private OutSideEffect _outSideEffect;

    private void Update()
    {
        transform.position = _data.transform.position;
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (collision.gameObject.layer == LayerMaskNumber.s_EnemyColliderSensor )
        {
            _outSideEffect.ActivateEffect();
        }
    }

    private void OnEnable()
    {
        if ( _data.CursorDirection.x > 0f )
        {
            transform.rotation = Quaternion.Euler( 0f, 0f, _data.AttackAngle );
        }
        else
        {
            transform.rotation = Quaternion.Euler( 180f, 0f, -_data.AttackAngle );
        }
    }
}
