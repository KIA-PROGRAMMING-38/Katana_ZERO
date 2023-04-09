using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrackRange : MonoBehaviour
{
    public Transform TargetTransform { get; private set; }

    private KnifeController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<KnifeController>();
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        // Patrol ���� �÷��̾ ���� ��� Track
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        // ���� �������� �÷��̾ ��� ��� Return Ȱ��ȭ
    }
}
