using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 primitiveMoveVec;

    private PlayerData _data;

    private void Awake()
    {
        _data = GetComponent<PlayerData>();
    }

    public void OnMove( InputValue value )
    {
        primitiveMoveVec = value.Get<Vector2>();
    }
}
