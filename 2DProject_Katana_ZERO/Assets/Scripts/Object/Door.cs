using LiteralRepository;
using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Animator _anim;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _anim = GetComponent<Animator>();
    }

    private void Open()
    {
        _anim.SetTrigger( "isOpen" );
        _collider.enabled = false;
    }
}
