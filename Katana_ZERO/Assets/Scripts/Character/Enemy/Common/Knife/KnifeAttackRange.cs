using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttackRange : MonoBehaviour
{
    private KnifeController _controller;

    private void Awake()
    {
        _controller = transform.root.GetComponent<KnifeController>();
    }

    private void OnTriggerStay2D( Collider2D collision )
    {
        // �÷��̾ AttackRange ���� ���� ��� Attack
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        // �÷��̾ AttackRange ���� ��� ��� �ٽ� Track
    }
}
