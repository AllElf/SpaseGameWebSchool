using UnityEngine;

public class RotationMobileVersion : MonoBehaviour
{
    public GameObject _followCamera;
    [SerializeField] GameObject _cameraZoom;
    [SerializeField] bool _zoom;
    [SerializeField] bool _rotate;
    [SerializeField] Transform _startPos;
    [SerializeField] Transform _endPos;
    [SerializeField] Transform _player;
    [SerializeField] float _speed;

    private void Start()
    {
        _followCamera = GameObject.Find("FolowCamera");
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _cameraZoom = Camera.main.gameObject;
        _zoom = false;
        _rotate = true;
    }
    private void OnMouseDrag()
    {
        if (_rotate == true)
        {
            _followCamera.transform.Rotate(0, 5f, 0);
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
        _zoom = true;
    }
    public void ZoomMinus()
    {
        _zoom = false;
    }
}
