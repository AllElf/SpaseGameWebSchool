using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] bool _cursorActiv;

    void Start()
    {
        _cursorActiv = true;
        _fpsCamera = Camera.main;
        //Cursor.lockState = CursorLockMode.Confined;
        ////Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
       
    }

    public void ButtonCursor()
    {
        _cursorActiv = !_cursorActiv;
        
    }

    private void FixedUpdate()
    {
        Cursors();
        if (_cursorActiv == false)
        {
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (_cursorActiv == true)
        {
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
        }
    }
    void Cursors()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ButtonCursor();  
        }
    }
    public void CursorPC()
    {
        _cursorActiv = !_cursorActiv;
    }

}
