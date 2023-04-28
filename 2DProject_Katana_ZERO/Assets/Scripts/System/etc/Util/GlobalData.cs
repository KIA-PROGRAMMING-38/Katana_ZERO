using UnityEngine;
using UnityEngine.Tilemaps;

namespace Util
{
    public class GlobalData : MonoBehaviour
    {
        public static GameObject PlayerGameObject;
        public static GameObject MouseCursorPosition;
        public static Transform PlayerTransform;

        public static Vector2 MouseScreenPos => _mouseScreenPos;
        private static Vector2 _mouseScreenPos;

        public static Vector2 MouseWorldPos => _mouseWorldPos;
        private static Vector2 _mouseWorldPos;

        private static Camera _mainCamera;

        // �� ĳ���Ͱ� ������� ���� ����
        // ����ִ� ���� Flat����, Slope������ ���� �̵� ���Ͱ� �����
        // ���߿� �� ������ ��� Empty
        public enum GroundState 
        {
            Default,
            Flat,
            Slope,
            OneWay,
            Empty
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _mouseScreenPos = Input.mousePosition;
            _mouseWorldPos = _mainCamera.ScreenToWorldPoint( _mouseScreenPos );
        }

        public static float GetAngleBetweenPlayerToMouse(Vector2 position)
        {
            Vector2 direction = _mouseWorldPos - position;

            return Mathf.Atan2( direction.y, direction.x ) * Mathf.Rad2Deg;
        }

        public static Vector2 GetDirectionBetweenTargetToMouse(Vector2 position)
        {
            return _mouseWorldPos - position;
        }
    }
}