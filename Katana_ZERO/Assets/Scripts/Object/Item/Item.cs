using LiteralRepository;
using UnityEngine;

public class Item : InteractionItem
{
    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.ExistAroundItem += EnableAnimation;
        controller.AlreadyHaveItem += CheckedUsed;
    }

    private void Update()
    {
        if ( flyingAway )
        {
            body.transform.Rotate( Vector3.forward, -rotationSpeed );
            rigid.velocity = transform.right * flyingSpeed;
        }
    }

    private void OnTriggerEnter( Collider other )
    {
        if ( other.gameObject.CompareTag( TagLiteral.FLOOR ) )
        {
            Destroy( gameObject );
        }
    }

    private void EnableAnimation( bool isActive )
    {
        if ( alreadyUsed == false )
        {
            if ( isActive )
            {
                ChangeState( animator, ItemAnimationLiteral.IDLE, ItemAnimationLiteral.INTERACTION );
            }
            else
            {
                ChangeState( animator, ItemAnimationLiteral.INTERACTION, ItemAnimationLiteral.IDLE );
            }
        }
    }

    private void CheckedUsed()
    {
        alreadyUsed = true;
    }
}
