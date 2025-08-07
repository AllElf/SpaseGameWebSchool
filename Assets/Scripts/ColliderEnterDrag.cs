using UnityEngine;

public class ColliderEnterDrag : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] CameraControllerPanel _cameraControllerPanel;
    [SerializeField] string _scriptControllerName = "_CameraControllerPanel";
    [SerializeField] float _speed;
    [SerializeField] float _currentSpeed = 60f;
    [SerializeField] string _nameTag;
    public bool _noJump;

    private void Start()
    {
        _speed = _currentSpeed;
        _cameraControllerPanel = GameObject.Find(_scriptControllerName).GetComponent<CameraControllerPanel>();
    }
 
    //private void OnTriggerEnter(Collider other)
    //{
    //    _speed = _currentSpeed;
    //    _nameTag = other.tag;
    //    _rb.drag = 10;
    //    _cameraControllerPanel.moveSpeedJoystick = _speed;
    //}
    private void OnTriggerStay(Collider other)
    {
        _noJump = false;
        _speed = _currentSpeed;
        _nameTag = other.tag;
        _rb.linearDamping = 10;
        _cameraControllerPanel.moveSpeedJoystick = _speed;
    }
    private void OnTriggerExit(Collider other)
    {
        _noJump = true;
        _speed = _currentSpeed /10;
        _nameTag = "";
        _rb.linearDamping = 0;
        _cameraControllerPanel.moveSpeedJoystick = _speed;
    }
    
}
