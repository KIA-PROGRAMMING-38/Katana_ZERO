using UnityEngine;

public abstract class EffectController : MonoBehaviour
{
    public abstract void Initialize();

    public virtual void PlayEffect()
    {

    }

    public virtual void PlayEffect( Transform targetTransfrom )
    {

    }

    public virtual void PlayEffect( Transform targetTransfrom, SpriteRenderer spriteRenderer )
    {

    }
}
