using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public void ChangeLayer( Transform transform, int newLayer )
    {
        transform.gameObject.layer = newLayer;

        foreach ( Transform child in transform )
        {
            ChangeLayer( child, newLayer );
        }
    }
}
