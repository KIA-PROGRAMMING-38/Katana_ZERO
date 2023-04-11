using StringLiteral;
using System.Collections;
using Unity.VisualScripting;
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
    }

    private void Update()
    {
        if ( _controller.TargetTransform != null )
        {
            _trackVec =
                ( _controller.TargetTransform.position - (Vector3)_controller.rigid.position ).normalized;
        }

        if ( _controller.PrevState == EnemyAnimationHash.s_AIM || 
            _controller.PrevState == EnemyAnimationHash.s_AIM )
        {
            _arms.gameObject.SetActive( true );
            _gun.gameObject.SetActive( true );
        }
        else
        {
            _arms.gameObject.SetActive( false );
            _gun.gameObject.SetActive( false );
        }

        if ( _controller.isShot )
        {
            float AttackAngle = Mathf.Atan2
                ( _trackVec.y, _trackVec.x ) * Mathf.Rad2Deg;

            BulletSpawnPoint.rotation = Quaternion.Euler( 0f, 0f, AttackAngle );

            GameObject shootBullet = Instantiate( BulletPrefap );
            Rigidbody bulletRigid = shootBullet.GetComponent<Rigidbody>();
            shootBullet.transform.position = BulletSpawnPoint.position;
            shootBullet.transform.rotation = BulletSpawnPoint.rotation;

            _controller.isShot = false;
        }
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == 11 )
        {
            OnDamaged();
        }
    }

    private void OnDamaged()
    {
        _controller.rigid.velocity = Vector2.zero;
        _animator.SetBool( _controller.PrevState, false );
        _animator.SetTrigger( EnemyAnimationHash.s_DIE );
        _controller.ChangeLayer( gameObject.transform, 9 );
    }
}
