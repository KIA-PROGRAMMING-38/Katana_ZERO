using LiteralRepository;
using UnityEngine;

public class SetActiveEffect : MonoBehaviour
{
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == LayerMaskNumber.s_Effect )
        {
            collision.GetComponent<LinearEffect>().Release();
        }
    }
}