using UnityEngine;
using LiteralRepository;

// 공격 충돌을 담당하는 스크립트
// TriggerEnter을 감지하면 Root 스크립트에게 메시지 전달
public class EnemyColliderSensor : MonoBehaviour
{
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) )
        {
            transform.root.SendMessage( FuncLiteral.OnDamaged );
        }
    }
}
