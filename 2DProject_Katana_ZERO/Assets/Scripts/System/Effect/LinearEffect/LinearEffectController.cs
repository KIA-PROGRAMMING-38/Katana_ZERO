using UnityEngine;
using Util;
using UnityEngine.Pool;

public class LinearEffectController : EffectController
{
    [Header( "Objects" )]
    [SerializeField]
    private LinearEffect _linearPrefabs;

    public IObjectPool<LinearEffect> _linearEffectPool;

    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        _linearEffectPool = new ObjectPool<LinearEffect>
            ( CreateInstantiate, OnGetEffect, OnReleaseEffect, OnDestroyEffect );
    }

    [SerializeField]
    [Range( 0f, 100f )]
    private float _distance;
    [SerializeField]
    [Range( 0f, 200f )]
    private float _velocityPower;
    public override void PlayEffect( Transform targetTransfrom )
    {
        LinearEffect linearEffect = _linearEffectPool.Get();

        Vector2 dir =
            ( targetTransfrom.position - GlobalData.PlayerTransform.position ).normalized;
        Vector2 normalVec = -1f * dir;
        Vector2 laserPosition = (Vector2)GlobalData.PlayerTransform.position + normalVec * _distance;
        float effectAngle = Mathf.Atan2
            ( dir.y, dir.x ) * Mathf.Rad2Deg;
        linearEffect.transform.position = laserPosition;
        linearEffect.transform.rotation = Quaternion.Euler( 0f, 0f, effectAngle );

        Rigidbody2D rigid = linearEffect.GetComponent<Rigidbody2D>();
        rigid.velocity = linearEffect.transform.right * _velocityPower;
    }

    private LinearEffect CreateInstantiate()
    {
        LinearEffect linearEffect = LinearEffect.Instantiate( _linearPrefabs );
        linearEffect.SetPoolReference( _linearEffectPool );

        return linearEffect;
    }

    private void OnGetEffect(LinearEffect linearEffect )
    {
        linearEffect.gameObject.SetActive( true );
    }

    private void OnReleaseEffect( LinearEffect linearEffect )
    {
        linearEffect.gameObject.SetActive( false );
    }

    private void OnDestroyEffect( LinearEffect linearEffect )
    {
        Destroy( linearEffect.gameObject );
    }
}
