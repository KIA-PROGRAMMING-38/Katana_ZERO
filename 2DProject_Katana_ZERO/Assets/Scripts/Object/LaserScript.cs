using LiteralRepository;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private ParticleSystem _laserParticle;

    private void Awake()
    {
        _laserParticle = GetComponentInChildren<ParticleSystem>();
        _laserParticle.Play();
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.gameObject.layer == LayerMaskNumber.s_Enemy ||
            collision.gameObject.layer == LayerMaskNumber.s_Player )
        {
            if ( collision != null )
            {
                collision.gameObject.transform.root.SendMessage( FuncLiteral.Burn );
            }
        }
    }
}
