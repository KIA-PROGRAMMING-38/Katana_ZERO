using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerData _data;
    private Camera _camera;

    public Vector2 primitiveMoveVec;
    public Vector2 PrimitiveMouseScreenPos;
    public Vector2 PrimitiveMouseWorldPos;

    private void Awake()
    {
        _data = GetComponent<PlayerData>();
        _camera = Camera.main;
    }

    private void Update()
    {
        PrimitiveMouseScreenPos = Input.mousePosition;
        PrimitiveMouseWorldPos = _camera.ScreenToWorldPoint( PrimitiveMouseScreenPos );
    }

    public void OnMove( InputValue value )
    {
        primitiveMoveVec = value.Get<Vector2>();
    }
}
