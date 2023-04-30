using LiteralRepository;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProperty : MonoBehaviour
{
    private Animator _animator;
    private CommonEnemyController _controller;
    private Rigidbody2D _rigid;

    [SerializeField]
    [Range(0f,100f)]
    private float _pushedBackPos;

    private AudioSource _audio;
    private List<AudioClip> _clips = new List<AudioClip>();

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CommonEnemyController>();
        _rigid = GetComponent<Rigidbody2D>();

        _controller.ThisEnemyType = Enemy.CommonEnemyType.Knife;

        _audio = GetComponent<AudioSource>();
        SetEffectClips();
    }

    private void Start()
    {
        _controller.CheckedOnDamage -= DamagedEffect;
        _controller.CheckedOnDamage += DamagedEffect;
    }

    private void DamagedEffect( bool onDamageable )
    {
        if ( onDamageable )
        {
            _controller.rigid.velocity = Vector2.zero;
            _controller.BodyAnimator.SetBool( _controller.PrevState, false );
            _controller.BodyAnimator.SetTrigger( EnemyAnimationHash.s_Die );
            _controller.ChangeLayer( gameObject.transform, LayerMaskNumber.s_DieEnemy );
            _controller.DrawBlood.TargetObject.Add( gameObject );
            _controller.DrawBlood.StartDrawBlood( _controller.DrawBlood.TargetObject.Count - 1 );

            Vector2 reflectedDirection = (Vector2)_controller.ThisIsPlayer.gameObject.transform.position
                - (Vector2)gameObject.transform.position;
            Vector2 normal = -reflectedDirection.normalized;

            _rigid.AddForce( normal  * _pushedBackPos, ForceMode2D.Impulse );
        }
        else
        {
            PlayEffectSound( 0 );
            _animator.SetBool( EnemyAnimationHash.s_Attack, false );
            _animator.SetBool( EnemyAnimationHash.s_KnockDown, true );
        }
    }

    private void SetEffectClips()
    {
        _clips.Add( DataHelper.LoadBGMClipHelper( AudioLiteral.BULLET_REFLECT ) );
    }

    public void PlayEffectSound( int index )
    {
        _audio.clip = _clips[index];
        AudioPlay();
    }

    private void AudioPlay()
    {
        _audio.playOnAwake = true;
        _audio.Play();
    }
}
