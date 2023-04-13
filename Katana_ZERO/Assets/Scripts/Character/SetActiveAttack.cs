using LiteralRepository;
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
            ( transform.position, _attackRadius, 1 << LayerMaskNumber.s_Player );

        foreach ( Collider2D elem in collision )
        {
            if ( elem != null )
            {
                if ( elem.gameObject.layer == LayerMaskNumber.s_Player )
                {
                    elem.transform.root.SendMessage( FuncLiteral.ONDAMAGED );
                }
            }
        }
    }
}
