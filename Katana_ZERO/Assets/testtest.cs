using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtest : MonoBehaviour
{
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag("PlayerKatanaEffect") )
        {
            gameObject.transform.root.SendMessage( "Test" );
        }
    }
}
