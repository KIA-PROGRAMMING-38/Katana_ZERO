using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LinearEffect : MonoBehaviour
{
    private IObjectPool<LinearEffect> _pool;
    private Rigidbody2D _rigid;

    public void SetPoolReference(IObjectPool<LinearEffect> pool)
    {
        _pool = pool;
    }

    public void Release()
    {
        _pool.Release(this);
    }
}
