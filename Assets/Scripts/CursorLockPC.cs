using UnityEngine;

public class CursorLockPC : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] bool _cursorActiv;

    void Start()
    {
        _cursorActiv = false;
        _fpsCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

    public void ButtonCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            _cursorActiv = !_cursorActiv;
        }
        else if (_cursorActiv == false)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (_cursorActiv == true)
        {
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void FixedUpdate()
    {
        ButtonCursor();
    }

}
