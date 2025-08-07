using UnityEngine;
public class RotationCameraTrigger : MonoBehaviour
{
    public GameObject _followCamera;
    [SerializeField] OnOffScript _offScript;
    [SerializeField] GameObject _cameraZoom;
    [SerializeField] GameObject _buttonPC;
    [SerializeField] bool _zoom;
    [SerializeField] bool _rotate;
    [SerializeField] Transform _startPos;
    [SerializeField] Transform _endPos;
    [SerializeField] Transform _player;
    [SerializeField]  float _speed;

    private void Start()
    {
        _buttonPC = GameObject.Find("Button (PC)");
        _offScript = GameObject.FindObjectOfType<OnOffScript>();
        _zoom = false;
        _rotate = true;
    }
    private void OnMouseDrag()
    {
        if(_rotate == true && _offScript._managementScriptPC == false)
        {
            _followCamera.transform.Rotate(0, 5f, 0);
        }
        else if (_offScript._managementScriptPC == true)
        {
            _followCamera.transform.Rotate(0, 0f, 0);
        }
    }

    private void FixedUpdate()
    {
        _cameraZoom.transform.LookAt(_followCamera.transform);
        if (_zoom == true)
        {
            _cameraZoom.transform.position = Vector3.MoveTowards(_cameraZoom.transform.position, _endPos.position, _speed * Time.deltaTime);
            _cameraZoom.transform.LookAt(_player.transform);
        }
        else if (_zoom == false)
        {
            _cameraZoom.transform.position = Vector3.MoveTowards(_cameraZoom.transform.position, _startPos.position, _speed * Time.deltaTime);
        }
    }

    public void ZoomPlus()
    {
        _rotate = false;
        _zoom = true;
        _buttonPC.SetActive(false);
    }
    public void ZoomMinus()
    {
        _rotate = true;
        _zoom = false;
        _buttonPC.SetActive(true);
    }
}
