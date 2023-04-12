using UnityEngine;

public class SetActiveAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackRadius;

    private void FixedUpdate()
    {
        CheckedCollision();
    }

    private void CheckedCollision()
    {
        Collider2D[] collision = Physics2D.OverlapCircleAll
            ( transform.position, _attackRadius, LayerMask.GetMask( "Player" ) );

        foreach ( Collider2D elem in collision )
        {
            if ( elem != null )
            {
                if ( elem.gameObject.layer == 7 )
                {
                    elem.transform.root.SendMessage( "OnDamaged" );
                }
            }
        }
    }
}
