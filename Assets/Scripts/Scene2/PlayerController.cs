using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float _speed = 7.5f;
    [SerializeField] float _jump;
    [SerializeField] bool _isGround = false;
    [SerializeField] float _horizontal, _vertical;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Camera cam;
    [SerializeField] GameObject _CameraObject;

    [SerializeField] Transform _startPos;
    [SerializeField] Transform _endPos;
    [SerializeField] Animator _animator;
    [SerializeField] string _nameAnimator = "Space_Soldier_A";
    [SerializeField] bool _stay, _walk, _run, _take, _jumpAnim;
    //[SerializeField] float camLookSpeed = 2.0f;
    //[SerializeField] float lookXLimit = 45;

    //float rotationX = 0;
    //float rotationY = 0;




    private void Start()
    {
        _stay = false;
        _walk = false;
        _run = false;
        _take = false;
        _jumpAnim = false;
        _CameraObject = Camera.main.gameObject;
        cam = _CameraObject.GetComponent<Camera>();
        _rb = GetComponent<Rigidbody>();
        _animator = GameObject.Find(_nameAnimator).GetComponent<Animator>();

    }

    private void Update()
    {
        AnimationsPC();
        CameraZoom();
        _horizontal = Input.GetAxis("Horizontal") * _speed;
        _vertical = Input.GetAxis("Vertical") * _speed;
        if (_isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (_isGround == false && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("������ �������");
        }
        TransformRot();
    }
    private void FixedUpdate()
    {
        ImplementationOfController();
        //HandleRotation();
    }

    void AnimationsPC()
    {
        _animator.SetBool("Stay", _stay);
        _animator.SetBool("Walk", _walk);
        _animator.SetBool("Run", _run);
        _animator.SetBool("Take", _take);
        _animator.SetBool("Jumper", _jumpAnim);

        if (_horizontal == 0 && _vertical == 0)
        {
            _stay = true;
            _walk = false;
            _run = false;
        }
        else if (_horizontal != 0 && !Input.GetKey(KeyCode.LeftShift) || _vertical != 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            _stay = false;
            _walk = true;
            _run = false;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && _horizontal != 0 || Input.GetKey(KeyCode.LeftShift) && _vertical != 0)
        {
            _stay = false;
            _walk = false;
            _run = true;
        }
        else
        {
            _stay = true;
            _walk = false;
            _run = false;
        }
    }
    void CameraZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _CameraObject.transform.position = Vector3.MoveTowards(_CameraObject.transform.position, _endPos.position, 1f);
            Debug.Log("�������� ��?");
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            _CameraObject.transform.position = Vector3.MoveTowards(_CameraObject.transform.position, _startPos.position, 1f);
            Debug.Log("�������� � ������ ������� ��?");
        }
    }
    void Jump()
    {
        Vector3 vec = new Vector3(0, 10f * _jump, 0);
        _rb.AddForce(vec);
    }
    private void OnCollisionStay(Collision collision)
    {

        //Debug.Log("��������");
        _isGround = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("�� ��������");
        _isGround = false;
    }
    void ImplementationOfController()
    {
        Vector2 axis = new Vector2(_vertical, _horizontal) * _speed;
        Vector3 forward = new Vector3(-cam.transform.right.z, 0.0f, cam.transform.right.x);
        Vector3 wishDirection = forward * axis.x + cam.transform.right * axis.y + Vector3.up * _rb.linearVelocity.y;
        _rb.linearVelocity = wishDirection;
    }
    //private void HandleRotation()
    //{
    //    rotationY += -Input.GetAxis("Mouse Y") * camLookSpeed;
    //    rotationX += -Input.GetAxis("Mouse X") * camLookSpeed;
    //    rotationY = Mathf.Clamp(rotationY, -lookXLimit, lookXLimit);
    //    cam.transform.localRotation = Quaternion.Euler(rotationY, -rotationX, 0);
    //}

    void TransformRot()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetMouseButton(1))
        {
            transform.right = cam.transform.right;
        }
        
    }
}