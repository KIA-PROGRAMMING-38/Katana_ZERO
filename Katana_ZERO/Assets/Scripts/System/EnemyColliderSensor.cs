using UnityEngine;
using LiteralRepository;

// ���� �浹�� ����ϴ� ��ũ��Ʈ
// TriggerEnter�� �����ϸ� Root ��ũ��Ʈ���� �޽��� ����
public class EnemyColliderSensor : MonoBehaviour
{
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) 
            || collision.gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            transform.root.SendMessage( FuncLiteral.OnDamaged );
        }
    }
}
