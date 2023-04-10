using StringLiteral;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class KnifeTrackRange : MonoBehaviour
{
    public Transform TargetTransform { get; private set; }

    private KnifeController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<KnifeController>();
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        if (TargetTransform == null && collision.CompareTag( TagLiteral.PLAYER ) )
        {
            Debug.Log( "hi trigger" );
            TargetTransform = collision.transform.root;
            _controller.TrackActive = true;
            Debug.Log( _controller.TrackActive );
        }
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        _controller.TrackActive = false;
    }
}
