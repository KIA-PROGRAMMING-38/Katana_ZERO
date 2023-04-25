using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolController : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab;
    private BulletPool _bulletPool;


    private void Awake()
    {
        _bulletPool.Initialize( _bulletPrefab );
        
        
    }
}
