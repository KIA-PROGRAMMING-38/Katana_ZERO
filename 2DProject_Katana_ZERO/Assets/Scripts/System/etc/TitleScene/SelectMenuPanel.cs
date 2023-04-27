using UnityEngine;

public class SelectMenuPanel : MonoBehaviour
{
    // 메뉴들 할당
    [SerializeField] private GameObject[] _menus;
    // 덮어 씌울 커서패널 할당
    [SerializeField] private GameObject _cursorPanel;
    // 코드에서 사용할 인덱스 선언
    private int selectedIndex;

    private void Awake()
    {
        // 초기화
        MoveCursorPosition();
    }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.UpArrow ) )
        {
            if ( selectedIndex > 0 )
            {
                --selectedIndex;
                MoveCursorPosition();
            }
        }
        else if ( Input.GetKeyDown( KeyCode.DownArrow ) ) 
        {
            if ( selectedIndex < _menus.Length - 1 )
            {
                ++selectedIndex; 
                MoveCursorPosition();
            }
        }
    }

    /// <summary>
    /// 인덱스의 변화에 따라 부모를 바꿔주는 함수 선언
    /// </summary>
    private void MoveCursorPosition()
    {
        _cursorPanel.transform.SetParent( _menus[selectedIndex].transform, false );
        _cursorPanel.transform.localPosition = Vector3.zero;
    }
}
