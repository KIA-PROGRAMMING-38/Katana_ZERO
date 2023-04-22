using System.Collections.Generic;
using UnityEngine;

public class OutSideEffect : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Transform _mouseCursorPos;
    [SerializeField]
    private GameObject[] _gameObjects;
    [SerializeField]
    private Transform _playerTransfrom;
    private Transform _targetPos;
    
    public Stack<GameObject> EffectObjects = new Stack<GameObject>();

    private void Awake()
    {
        foreach ( GameObject elem in _gameObjects )
        {
            EffectObjects.Push( elem );
            elem.SetActive( false );
        }
    }

    [SerializeField]
    [Range( 0f, 10f )]
    private float _distance;
    [SerializeField]
    [Range( 0f, 50f )]
    private float _velocityPower;
    public void ActivateEffect()
    {
        GameObject gameObject = EffectObjects.Pop();
        gameObject.SetActive( true );
        Vector2 dir = 
            ( _mouseCursorPos.transform.position - _playerTransfrom.position ).normalized;
        Vector2 normalVec = -1f * dir;
        Vector2 laserPosition = (Vector2)_playerTransfrom.position + normalVec * _distance;
        float effectAngle = Mathf.Atan2
            ( dir.y, dir.x ) * Mathf.Rad2Deg;
        gameObject.transform.position = laserPosition;
        gameObject.transform.rotation = Quaternion.Euler( 0f, 0f, effectAngle );

        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.velocity = gameObject.transform.right * _velocityPower;
    }
}
