using UnityEngine;
using LiteralRepository;

// 공격 충돌을 담당하는 스크립트
// TriggerEnter을 감지하면 Root 스크립트에게 메시지 전달
public class EnemyColliderSensor : MonoBehaviour
{
    [SerializeField]
    private LinearEffectController _linearController;

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) 
            || collision.gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            transform.root.SendMessage( FuncLiteral.OnDamaged );
            _linearController?.PlayEffect( gameObject.transform );
        }
    }
}
