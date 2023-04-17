using LiteralRepository;
using System;
using UnityEngine;


public class GunProperty : MonoBehaviour
{
    private Animator _animator;
    private CommonEnemyController _controller;
    private Rigidbody2D _rigid;

    [SerializeField]
    private GameObject _arms;
    [SerializeField]
    private GameObject _gun;
    [SerializeField]
    [Range( 0f, 100f )]
    private float _pushedBackPos;

    public Transform TargetTransform;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefap;

    private Vector2 _trackVec;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CommonEnemyController>();
        _rigid = GetComponent<Rigidbody2D>();

        _controller.ThisEnemyType = Enemy.CommonEnemyType.Gun;
    }

    private void Start()
    {
        _controller.CheckedOnDamage -= DamagedEffect;
        _controller.CheckedOnDamage += DamagedEffect;
        _controller.ReadyToAttack -= TakeAim;
        _controller.ReadyToAttack += TakeAim;
        _controller.RestoreCondition -= TakeDown;
        _controller.RestoreCondition += TakeDown;
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == LayerMaskNumber.s_ReflectedBullet )
        {
            DamagedEffect( true );
        }
    }

    private void DamagedEffect( bool onDamageable )
    {
        _controller.rigid.velocity = Vector2.zero;
        _animator.SetBool( _controller.PrevState, false );
        _animator.SetTrigger( EnemyAnimationHash.s_Die );
        _controller.ChangeLayer( gameObject.transform, LayerMaskNumber.s_DieEnemy );
        _controller.DrawBlood.TargetObject.Add( gameObject );
        _controller.DrawBlood.StartDrawBlood( _controller.DrawBlood.TargetObject.Count - 1 );

        Vector2 reflectedDirection = (Vector2)_controller.ThisIsPlayer.gameObject.transform.position
            - (Vector2)gameObject.transform.position;
        Vector2 normal = -reflectedDirection.normalized;

        _rigid.AddForce( normal  * _pushedBackPos, ForceMode2D.Impulse );
    }

    private void TakeAim()
    {
        _arms.gameObject.SetActive( true );
        _gun.gameObject.SetActive( true );

        _trackVec =
                ( _controller.TargetTransform.position - (Vector3)_controller.rigid.position ).normalized;

        float AttackAngle = Mathf.Atan2
                ( _trackVec.y, _trackVec.x ) * Mathf.Rad2Deg;

        BulletSpawnPoint.rotation = Quaternion.Euler( 0f, 0f, AttackAngle );

        GameObject shootBullet = Instantiate( BulletPrefap );
        Rigidbody bulletRigid = shootBullet.GetComponent<Rigidbody>();
        shootBullet.transform.position = BulletSpawnPoint.position;
        shootBullet.transform.rotation = BulletSpawnPoint.rotation;

        _controller.isShot = false;
    }

    private void TakeDown()
    {
        _arms.gameObject.SetActive( false );
        _gun.gameObject.SetActive( false );
    }
}
