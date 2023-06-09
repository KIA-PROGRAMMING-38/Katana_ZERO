using LiteralRepository;
using UnityEngine;

public class CommonEnemyAttackRange : MonoBehaviour
{
    private CommonEnemyController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<CommonEnemyController>();
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == LayerMaskNumber.s_PlayerColliderSensor )
        {
            _controller.AttackActive = true;
        }
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == LayerMaskNumber.s_PlayerColliderSensor )
        {
            _controller.AttackActive = false;
        }
    }
}
