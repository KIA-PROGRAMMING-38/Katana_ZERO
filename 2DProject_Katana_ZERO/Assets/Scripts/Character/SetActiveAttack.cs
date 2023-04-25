using LiteralRepository;
using UnityEngine;

public class SetActiveAttack : MonoBehaviour
{
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.CompareTag( TagLiteral.PLAYER ) )
        {

        }
    }
}
