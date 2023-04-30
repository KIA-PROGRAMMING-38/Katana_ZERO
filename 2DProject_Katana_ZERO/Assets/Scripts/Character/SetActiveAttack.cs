using LiteralRepository;
using UnityEngine;
using Util;

public class SetActiveAttack : MonoBehaviour
{
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
