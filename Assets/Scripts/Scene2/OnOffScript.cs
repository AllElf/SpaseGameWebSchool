using UnityEngine;

public class OnOffScript : MonoBehaviour
{
    [SerializeField] MovePoints _movePoints;
    [SerializeField] RotationCameraTrigger _rotationCameraTrigger;
    [SerializeField] PlayerController _playerController;
    [SerializeField] CameraControllerX _cameraControllerX;
    [SerializeField] GameObject _panelMobile;
    [SerializeField] GameObject _panelPC;
    [SerializeField] GameObject _objrctJump;
    [SerializeField] GameObject _Camera;
    [SerializeField] GameObject _followCamera;
    [SerializeField] Vector3 _positionFollowCamera;
    [SerializeField] Quaternion _rotationFollowCamera;
    [SerializeField] Vector3 _positionCamera;
    [SerializeField] Quaternion _rotationCamera;
    [SerializeField] GameObject _playerMobile;
    [SerializeField] GameObject _playerPC;
    [SerializeField] string _panelMobileCanvas = "PanelMobile";
    [SerializeField] string _panelPCCanvas;
    public bool _managementScriptPC;

    private void Awake()
    {
        _Camera = Camera.main.gameObject;
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _rotationCameraTrigger = GameObject.FindObjectOfType<RotationCameraTrigger>();
        _playerController = GameObject.FindObjectOfType<PlayerController>();
        _cameraControllerX = GameObject.FindObjectOfType<CameraControllerX>();
        _panelMobile = GameObject.Find(_panelMobileCanvas);
        _objrctJump = GameObject.Find("JumpTrigger");
        _managementScriptPC = false;
        _rotationCamera = _Camera.transform.rotation;
        _positionCamera = _Camera.transform.position;
        _followCamera = _rotationCameraTrigger._followCamera;
        _positionFollowCamera = _followCamera.transform.position;
        _rotationFollowCamera = _followCamera.transform.rotation;
    }
    private void Start()
    {
        _playerController.enabled = false;
        _cameraControllerX.enabled = false;
        _movePoints.enabled = true;
        _rotationCameraTrigger.enabled = true;
        _panelMobile.SetActive(true);
        _objrctJump.SetActive(true);
        _playerMobile = GameObject.Find("Space_Soldier_A");
        _playerPC = GameObject.Find("Space_Soldier_A_PC");
        _playerPC.SetActive(false);
    }

    //void ScriptManager()
    //{
    //    if (_managementScriptPC == true)
    //    {

    //    }
    //    else if (_managementScriptPC == false)
    //    {

    //    }
    //}

    public void PC()
    {
        _managementScriptPC = !_managementScriptPC;
        if (_managementScriptPC == false)
        {
            _Camera.transform.position = _positionCamera;
            _Camera.transform.rotation = _rotationCamera;
            _followCamera.transform.position = _positionFollowCamera;
            _followCamera.transform.rotation = _rotationFollowCamera;
            _playerController.enabled = false;
            _cameraControllerX.enabled = false;
            _movePoints.enabled = true;
            _rotationCameraTrigger.enabled = true;
            _panelMobile.SetActive(true);
            _objrctJump.SetActive(true);
            _playerPC.SetActive(false);
            _playerMobile.SetActive(true);
        }
        else if (_managementScriptPC == true)
        {
            _movePoints.enabled = false;
            _playerPC.SetActive(true);
            _playerMobile.SetActive(false);
            _rotationCameraTrigger.enabled = false;
            _panelMobile.SetActive(false);
            _objrctJump.SetActive(false);
            _playerController.enabled = true;
            _cameraControllerX.enabled = true;
        }
    }
}
