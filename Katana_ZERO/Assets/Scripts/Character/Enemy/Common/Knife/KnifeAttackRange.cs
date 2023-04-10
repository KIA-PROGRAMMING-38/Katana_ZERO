using StringLiteral;
using UnityEngine;

public class KnifeAttackRange : MonoBehaviour
{
    private CommonEnemyController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<CommonEnemyController>();
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER ) )
        {
            _controller.AttackActive = true;
        }
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER ) )
        {
            _controller.AttackActive = false;
        }
    }
}
