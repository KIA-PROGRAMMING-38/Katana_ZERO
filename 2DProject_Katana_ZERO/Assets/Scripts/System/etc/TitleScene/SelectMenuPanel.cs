using UnityEngine;

public class SelectMenuPanel : MonoBehaviour
{
    // �޴��� �Ҵ�
    [SerializeField] private GameObject[] _menus;
    // ���� ���� Ŀ���г� �Ҵ�
    [SerializeField] private GameObject _cursorPanel;
    // �ڵ忡�� ����� �ε��� ����
    private int selectedIndex;

    private void Awake()
    {
        // �ʱ�ȭ
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
    /// �ε����� ��ȭ�� ���� �θ� �ٲ��ִ� �Լ� ����
    /// </summary>
    private void MoveCursorPosition()
    {
        _cursorPanel.transform.SetParent( _menus[selectedIndex].transform, false );
        _cursorPanel.transform.localPosition = Vector3.zero;
    }
}
