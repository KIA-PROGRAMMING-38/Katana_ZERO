using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject _setActiveAttack;
    protected Animator animator;

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
