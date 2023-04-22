using UnityEngine;
using Util.Pool;

public class BulletPool
{
    private Bullet _bulletPrefab;
    
    public ObjectPool<Bullet> _bulletPool;

    public Bullet GetBulletFromPool() => _bulletPool.Get();

    public void Initialize(Bullet bulletPrefab)
    {
        InitializeBulletPool();

        _bulletPrefab = bulletPrefab;
    }

    private void InitializeBulletPool() => _bulletPool = new ObjectPool<Bullet>(
        CreateBullet, OnGetBulletFromPool, OnReleaseBulletToPool, OnDestroyBullet );

    private Bullet CreateBullet()
    {
        Bullet bullet = Object.Instantiate( _bulletPrefab );
        // bullet.SetPoolReference( _bulletPool );

        return bullet;
    }

    private void OnGetBulletFromPool( Bullet bullet ) => bullet.gameObject.SetActive( true );
    private void OnReleaseBulletToPool( Bullet bullet ) => bullet.gameObject.SetActive( false );
    private void OnDestroyBullet( Bullet bullet ) => Object.Destroy( bullet.gameObject );
}