using LiteralRepository;
using UnityEngine;

public class CommonEnemyTrackRange : MonoBehaviour
{
    public Transform TargetObject { get; private set; }

    private CommonEnemyController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<CommonEnemyController>();
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {

        if ( TargetObject == null && collision.gameObject.layer == LayerMaskNumber.s_PlayerColliderSensor )
        {
            TargetObject = collision.transform.root;
            _controller.TrackActive = true;
            _controller.TargetTransform = TargetObject;
        }
    }
}
