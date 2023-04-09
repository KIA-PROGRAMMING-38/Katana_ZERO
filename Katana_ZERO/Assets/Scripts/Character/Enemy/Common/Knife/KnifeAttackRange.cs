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
        // 플레이어가 AttackRange 내에 들어올 경우 Attack
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        // 플레이어가 AttackRange 에서 벗어날 경우 다시 Track
    }
}
