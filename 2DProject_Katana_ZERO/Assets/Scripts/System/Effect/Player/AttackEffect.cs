using LiteralRepository;
using UnityEditor;
using UnityEngine;
using Util;

public class AttackEffect : MonoBehaviour
{
    [SerializeField] 
    private Transform _targetPos;
    [SerializeField] 
    private PlayerData _data;
    [SerializeField]
    private LinearEffectController _linearEffectController;

    private void Update()
    {
        transform.position = _data.transform.position;

        if ( _data.gameObject.activeSelf == false )
        {
            gameObject.SetActive( false );
        }
    }

    private void OnEnable()
    {
        if ( _data.CursorDirection.x > 0f )
        {
            transform.rotation = Quaternion.Euler( 0f, 0f, _data.AttackAngle );
        }
        else
        {
            transform.rotation = Quaternion.Euler( 180f, 0f, -_data.AttackAngle );
        }
    }
}
