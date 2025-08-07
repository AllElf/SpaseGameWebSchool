using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class CharacrerManagement : MonoBehaviour
{
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] GameObject _joystickGameObject;

    [SerializeField] float _moveSpeed;
    [SerializeField] float _horizontal, _vertical;

    [SerializeField] bool _enabled;


    public float _heathPlayer = 1000f;
    public float _damagePlayer;
    [SerializeField] float _speed;
    [SerializeField] float _radian_angle;
    [SerializeField] float _jump;
    public float _range;
    public bool _isGround;
    [SerializeField] bool _isWalk;
    public GameObject newTarget;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject chaild;
    [SerializeField] Animator _animator;
    Vector3 vec;
    [SerializeField] string _nameAnimator = "Space_Soldier_A";
    [SerializeField] GameObject[] _gameObject;
    [SerializeField] float[] _enamyDist;
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject _canvasGameOver;
    [SerializeField] Image _imageHalth;

    [SerializeField] float _speedSpawn;
    BulletSpawn _bulletSpawn;

    GameObject _head;
    GameObject _defaultView;




    private void Start()
    {
        _isGround = true;
        _isWalk = false;
        _enabled = false;
        _animator = GameObject.Find(_nameAnimator).GetComponent<Animator>();
        _animator.SetBool("isWalk", _isWalk);
        rb = GetComponent<Rigidbody>();
        _gun = GameObject.Find("GUN");
        _bulletSpawn = GameObject.FindObjectOfType<BulletSpawn>();
        _imageHalth = GameObject.Find("HealthImagePlayer").GetComponent<Image>();
        _head = GameObject.Find("HeadSolder");
        _defaultView = GameObject.Find("DefaultView");
    }
    private void FixedUpdate()
    {
        _animator.SetBool("isWalk", _isWalk);
        _imageHalth.fillAmount = _heathPlayer / 1000f;
        if (_enabled == true)
        {
            JoystickMove();
        }
        else if(_enabled == false)
        {
            Move();
        }
        SearchEnamy();
        GameOver();
    }

    void JoystickMove()
    {
        _joystickGameObject.SetActive(true);
        rb.linearVelocity = new Vector3(_joystick.Horizontal * _moveSpeed, rb.linearVelocity.y, _joystick.Vertical * _moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _isWalk = true;
            transform.rotation = Quaternion.LookRotation(rb.linearVelocity);
        }
        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            _isWalk = false;
        }
    }
    void Move()
    {
        _joystickGameObject.SetActive(false);
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector3(_horizontal * _moveSpeed, rb.linearVelocity.y, _vertical * _moveSpeed);
        if (_horizontal != 0 || _vertical != 0)
        {
            _isWalk = true;
            transform.rotation = Quaternion.LookRotation(rb.linearVelocity);
        }
        else if (_horizontal == 0 && _vertical == 0)
        {
            _isWalk = false;
        }
    }

    void SearchEnamy()
    {
        _gameObject = GameObject.FindGameObjectsWithTag("Enamy");
        _enamyDist = new float[_gameObject.Length];
        if (_gameObject.Length != 0)
        {
            for (int i = 0; i < _gameObject.Length; i++)
            {
                _enamyDist[i] = Vector3.Distance(transform.position, _gameObject[i].transform.position);

                for (int j = 0; j < _gameObject.Length; j++)
                {
                    if (_enamyDist.Min() < _range && Vector3.Distance(transform.position, _gameObject[j].transform.position) == _enamyDist.Min())
                    {
                        Vector3 targetPosition = new Vector3(_gameObject[j].transform.position.x, transform.position.y, _gameObject[j].transform.position.z);
                        Vector3 Move = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
                        transform.LookAt(Move);
                        _head.transform.LookAt(_gameObject[j].transform);
                        _gun.transform.LookAt(_gameObject[j].transform);

                    }
                    else if (_enamyDist.Min() > _range)
                    {
                        Vector3 targetPosition = new Vector3(chaild.transform.position.x, transform.position.y, chaild.transform.position.z);
                        Vector3 Move = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
                        transform.LookAt(Move);
                        _head.transform.LookAt(_defaultView.transform.position);
                        _gun.transform.rotation = gameObject.transform.rotation;
                    }
                }
            }
        }
        else if (_gameObject.Length == 0)
        {
            Vector3 targetPosition = new Vector3(chaild.transform.position.x, transform.position.y, chaild.transform.position.z);
            Vector3 Move = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            transform.LookAt(Move);
            _head.transform.LookAt(_defaultView.transform.position);
            _gun.transform.rotation = gameObject.transform.rotation;
        }
    }

    void GameOver()
    {
        if (_heathPlayer <= 0)
        {
            _heathPlayer = 0;
            if (_heathPlayer == 0)
            {
                Debug.Log("�� �������");
                _canvasGameOver.SetActive(true);
            }
        }
        else if (_heathPlayer >= 1000f)
        {
            _heathPlayer = 1000f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "")
        {
            Debug.Log("���� ��� �����");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == newTarget.gameObject)
        {
            _isWalk = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == newTarget.gameObject)
        {
            _isWalk = true;
        }
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

}
