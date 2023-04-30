using LiteralRepository;
using UnityEngine;
using Util;

public class SetAttackPointTransform : MonoBehaviour
{
    private CommonEnemyController _controller;

    private void OnEnable()
    {
        _controller = transform.root.GetComponent<CommonEnemyController>();

        Vector2 currentPosition = _controller.gameObject.transform.position;
        float attackAngle = GlobalData.GetAngleBetweenEnemyToPlayer(currentPosition);

        if ( _controller.FacingDirection > 0f )
        {
            transform.rotation = Quaternion.Euler( 0f, 0f, attackAngle );
        }
        else
        {
            transform.rotation = Quaternion.Euler( 180f, 0f, -attackAngle );
        }
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive( false );
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == LayerMaskNumber.s_PlayerColliderSensor )
        {
            PlayerController playerController 
                = GlobalData.PlayerGameObject.GetComponent<PlayerController>();

            playerController.OnDamaged( gameObject.transform.root.position );
        }
    }
}
