using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.Pool;

public class LinearEffect : MonoBehaviour
{
    private IObjectPool<LinearEffect> _pool;

    public void SetPoolReference(IObjectPool<LinearEffect> pool)
    {
        _pool = pool;
    }

    public void Release()
    {
        _pool.Release(this);
    }
}
