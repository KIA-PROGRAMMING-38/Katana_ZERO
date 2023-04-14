using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {

    }
}
