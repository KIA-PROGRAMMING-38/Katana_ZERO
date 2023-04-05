using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerData _data;
    private Camera _camera;

    public Vector2 primitiveMoveVec;
    private Vector2 MouseScreenPos;
    public Vector2 MouseWorldPos;

    private void Awake()
    {
        _data = GetComponent<PlayerData>();
        _camera = Camera.main;
    }

    private void Update()
    {
        MouseScreenPos = Input.mousePosition;
        MouseWorldPos = _camera.ScreenToWorldPoint( MouseScreenPos );
    }

    public void OnMove( InputValue value )
    {
        primitiveMoveVec = value.Get<Vector2>();
    }
}
