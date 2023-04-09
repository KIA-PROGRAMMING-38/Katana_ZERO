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
        // Patrol 도중 플레이어를 만날 경우 Track
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        // 감지 범위에서 플레이어가 벗어날 경우 Return 활성화
    }
}
