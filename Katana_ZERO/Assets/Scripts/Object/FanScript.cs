using LiteralRepository;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Util;

public class FanScript : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;
    
    private Animator _anim;
    private SpriteRenderer _sprite;
    private BoxCollider2D _boxCollider;

    private bool _isSlowTime;
    private bool _isPossibleCross;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

        _timeManager.OnActiveSlowTime -= CaptureSlowTime;
        _timeManager.OnActiveSlowTime += CaptureSlowTime;

        _timeManager.DeActiveSlowTime -= EscapeSlowTime;
        _timeManager.DeActiveSlowTime += EscapeSlowTime;

        EscapeSlowTime();
    }

    private void Update()
    {
        if ( _isSlowTime )
        {
            if ( _isPossibleCross )
            {
                _boxCollider.enabled = false;
                _sprite.color = Color.white;
            }
            else if ( !_isPossibleCross )
            {
                _boxCollider.enabled = true;
                _sprite.color = Color.red;
            }
        }
        else if ( !_isSlowTime )
        {
            _boxCollider.enabled = true;
            _sprite.color = Color.white;
        }
    }

    private void CaptureSlowTime()
    {
        _anim.speed = 2f;
        _isSlowTime = true;
    }

    private void EscapeSlowTime()
    {
        _anim.speed = 100f;
        _isSlowTime = false;
    }

    public void OnDisableCollider()
    {
        _isPossibleCross = true;
    }

    public void OnEnableCollider()
    {
        _isPossibleCross = false;
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER ) )
        {
            Rigidbody2D rigid = GlobalData.PlayerGameObject.GetComponent<Rigidbody2D>();
            Vector2 reflectedDirection = (Vector2)gameObject.transform.position
                - (Vector2)GlobalData.PlayerTransform.position;
            Vector2 normal = -reflectedDirection.normalized;
            
            rigid.AddForce( normal * 22f, ForceMode2D.Impulse );
        }
    }
}
