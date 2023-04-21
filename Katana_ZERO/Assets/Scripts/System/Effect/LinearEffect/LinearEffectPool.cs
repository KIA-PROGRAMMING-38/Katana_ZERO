using UnityEngine;
using Util.Pool;

public class LinearPool
{
    private LinearEffect _linearEffectPrefab;
    private ObjectPool<LinearEffect> _linearEffectPool;

    public LinearEffect GetLinearEffectFromPool() => _linearEffectPool.Get();

    public void Initialize( LinearEffect linearEffectPrefab )
    {
        _linearEffectPrefab = linearEffectPrefab;

        InitializeLinearEffectPool();
    }

    private void InitializeLinearEffectPool() => _linearEffectPool = new ObjectPool<LinearEffect>(
        CreateLinearEffect, OnGetLinearEffectFromPool, OnReleaseLinearEffectToPool, OnDestroyLinearEffect );

    private LinearEffect CreateLinearEffect()
    {
        LinearEffect linearEffect = Object.Instantiate( _linearEffectPrefab );
        // linearEffect.SetPoolRef( _linearEffectPool );

        return linearEffect;
    }

    private void OnGetLinearEffectFromPool( LinearEffect linearEffect ) 
        => linearEffect.gameObject.SetActive( true );
    private void OnReleaseLinearEffectToPool( LinearEffect linearEffect ) 
        => linearEffect.gameObject.SetActive( false );
    private void OnDestroyLinearEffect( LinearEffect linearEffect ) 
        => Object.Destroy( linearEffect.gameObject );
}