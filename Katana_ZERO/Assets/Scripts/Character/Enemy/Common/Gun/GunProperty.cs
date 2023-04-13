using LiteralRepository;
using System;
using UnityEngine;


public class GunProperty : MonoBehaviour
{

    private Animator _animator;
    private CommonEnemyController _controller;

    [SerializeField]
    private GameObject _arms;
    [SerializeField]
    private GameObject _gun;

    public Transform TargetTransform;
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefap;

    private Vector2 _trackVec;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CommonEnemyController>();

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
