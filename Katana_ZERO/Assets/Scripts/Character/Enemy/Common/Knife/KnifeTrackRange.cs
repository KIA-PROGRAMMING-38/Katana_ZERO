using StringLiteral;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class KnifeTrackRange : MonoBehaviour
{
    public Transform TargetObject { get; private set; }

    private KnifeController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<KnifeController>();
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if ( TargetObject == null && collision.CompareTag( TagLiteral.PLAYER ) )
        {
            TargetObject = collision.transform.root;
            _controller.TrackActive = true;
            _controller.TargetTransform = TargetObject;
        }
    }
}
