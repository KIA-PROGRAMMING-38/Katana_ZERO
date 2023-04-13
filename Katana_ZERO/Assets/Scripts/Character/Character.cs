using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract void OnDamaged();

    public void ChangeLayer( Transform transform, int newLayer )
    {
        transform.gameObject.layer = newLayer;

        foreach ( Transform child in transform )
        {
            ChangeLayer( child, newLayer );
        }
    }
}
