using LiteralRepository;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Timeline;
using Util;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(10f, 100f)]
    public float _bulletSpeed = 10f;
    private Rigidbody2D _rigid;

    private IObjectPool<Bullet> _pool;

    private AudioSource _audio;
    private List<AudioClip> _clips = new List<AudioClip>();

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();

        SetSoundClips();
    }

    private void Update()
    {
        _rigid.velocity = transform.right * _bulletSpeed;
    }

    public void SetPoolReference( IObjectPool<Bullet> pool ) => _pool = pool;
    public void Release() => _pool.Release( this );


    private void OnTriggerEnter2D( Collider2D collision )
    {
        // �ٴ� Ȥ�� �÷��̾�� �´���� �� Ǯ�� �ٽ� ����־� ��
        if ( collision.CompareTag( TagLiteral.GROUND )  )
        {
            Release();
        }

        if ( collision.CompareTag( TagLiteral.PLAYER ))
        {
            Release();
            PlayEffectSound( 0 );
            GlobalData.PlayerGameObject.GetComponent<PlayerController>().OnDamaged( gameObject.transform.position );
        }

        // �÷��̾ ���� �ݻ�Ǵ� �Ѿ��� ��쿡�� ���ʹ̿��� Ÿ���� �� �� �ֵ��� ����
        if ( gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            if ( collision.CompareTag( TagLiteral.ENEMY ) )
            {
                // ���ʹ̰� �Ѿ˿� ���� ���, OutsideEffect ����
                collision.GetComponent<CommonEnemyController>().LinearEffectController.PlayEffect(collision.transform);
                PlayEffectSound( 0 );
                Release();
            }
        }

        // �÷��̾�� ���ϴ� �Ѿ��� �÷��̾ ƨ�ܳ� ���, �Ѿ��� ƨ�ܳ� �������� �ǵ��ư���
        if ( collision.CompareTag( TagLiteral.PLAYER_KATANA_EFFECT ) )
        {
            PlayEffectSound( 1 );
            Reflection( collision );
        }
     }

    private void Reflection( Collider2D collision )
    {
        // �ݻ�Ǵ� �Ѿ��� ���̾ ����
        gameObject.layer = LayerMaskNumber.s_ReflectedBullet;

        Vector2 normal = collision.transform.right * -1f;
        Vector2 reflectedDirection = Vector2.Reflect( _rigid.velocity.normalized, normal );
        _rigid.velocity = reflectedDirection * _bulletSpeed;

        float reflectAngle = Mathf.Atan2
        ( reflectedDirection.y, reflectedDirection.x ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( 0f, 0f, reflectAngle );
    }

    private void PlayEffectSound(int index)
    {
        _audio.clip = _clips[index];
        AudioPlay();
    }

    private void SetSoundClips()
    {
        _clips.Add( DataHelper.LoadBGMClipHelper( "Bullet_Die" ) );
        _clips.Add( DataHelper.LoadBGMClipHelper( "Bullet_Reflect" ) );
    }

    private void AudioPlay()
    {
        _audio.playOnAwake = true;
        _audio.Play();
    }
}
