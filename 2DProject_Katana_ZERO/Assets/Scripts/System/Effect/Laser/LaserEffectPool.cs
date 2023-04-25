using UnityEngine;
using Util.Pool;

public class LaserEffectPool
{
    private DieLaserEffect _dieLaserEffectPrefab;
    private ObjectPool<DieLaserEffect> _dieLaserPool;

    public DieLaserEffect GetDieLaserEffectFromPool() => _dieLaserPool.Get();

    public void Initialize( DieLaserEffect dieLaserPrefab )
    {
        _dieLaserEffectPrefab = dieLaserPrefab;
    }

    private void InitializeDieLaserEffectPool() => _dieLaserPool = new ObjectPool<DieLaserEffect>(
        CreateDieLaserEffect, OnGetDieLaserFromPool, OnReleaseDieLaserToPool, OnDestroyDieLaser );

    private DieLaserEffect CreateDieLaserEffect()
    {
        DieLaserEffect dieLaserPrefab = Object.Instantiate( _dieLaserEffectPrefab );
        dieLaserPrefab.SetPoolRef( _dieLaserPool );

        return dieLaserPrefab;
    }

    private void OnGetDieLaserFromPool( DieLaserEffect dieLaserPrefab ) => dieLaserPrefab.gameObject.SetActive( true );
    private void OnReleaseDieLaserToPool( DieLaserEffect dieLaserPrefab ) => dieLaserPrefab.gameObject.SetActive( false );
    private void OnDestroyDieLaser( DieLaserEffect dieLaserPrefab ) => Object.Destroy( dieLaserPrefab.gameObject );
}