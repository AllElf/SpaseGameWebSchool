using System.Linq;
using UnityEngine.UI;
using UnityEngine;


public class MovePoints : MonoBehaviour
{
    public float _heathPlayer = 1000f;
    public float _damagePlayer;
    [SerializeField] float _speed;
    //[SerializeField] float _radian_angle;
    [SerializeField] float _jump;
    public float _range;
    public bool _isGround;
    [SerializeField] bool _isWalk;
    [SerializeField] bool _gameOver;
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


    WriteToFile _writeToFile;


    private void Start()
    {
        _gameOver = false;
        if (GameObject.FindObjectOfType<WriteToFile>() != null)
        {
            _writeToFile = GameObject.FindObjectOfType<WriteToFile>();
        }
        _isGround = true;
        _isWalk = false;
        newTarget = Instantiate(newTarget, newTarget.transform.position.normalized, newTarget.transform.rotation.normalized);
        newTarget.transform.position = transform.position;
        newTarget.transform.rotation = transform.rotation;
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
        _imageHalth.fillAmount = _heathPlayer/1000f;
        if (Input.GetMouseButton(0))
        {
            SetTarget();
        }
        if(newTarget != null)
        {
            Move();
        }
        SearchEnamy();
        //GameOver();
    }

    private void Update()
    {
        GameOver();
    }


    void SetTarget()
    {
        RaycastHit _hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
        {
            if(_hit.collider == null && _hit.collider.tag != "Ground")
            {
                return;
            }
            else if (_hit.collider != null && _hit.collider.tag == "Ground")
            {
                vec = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
                newTarget.transform.position = vec;
                chaild = newTarget.transform.GetChild(0).gameObject;
            }
        }
    }
    void SearchEnamy()
    {
        //if(GameObject.FindGameObjectsWithTag("Enamy") != null && GameObject.FindGameObjectsWithTag("EnamyTrigger") != null)
        _gameObject = GameObject.FindGameObjectsWithTag("Enamy");
        _enamyDist = new float[_gameObject.Length];
        if(Input.GetMouseButton(0) && _gameObject.Length != 0)
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
                    else if(_enamyDist.Min() > _range)
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
        else if (Input.GetMouseButton(0) && _gameObject.Length == 0)
        {
            Vector3 targetPosition = new Vector3(chaild.transform.position.x, transform.position.y, chaild.transform.position.z);
            Vector3 Move = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            transform.LookAt(Move);
            _head.transform.LookAt(_defaultView.transform.position);
            _gun.transform.rotation = gameObject.transform.rotation;
        }
        
        else if (!Input.GetMouseButton(0))
        {
            for (int i = 0; i < _gameObject.Length; i++)
            {
                _enamyDist[i] = Vector3.Distance(transform.position, _gameObject[i].transform.position);

                for (int j = 0; j < _gameObject.Length; j++)
                {
                    if (_enamyDist.Min() < _range && Vector3.Distance(transform.position, _gameObject[j].transform.position) == _enamyDist.Min())
                    {
                        Vector3 targetPosition = new Vector3(_gameObject[j].transform.position.x, transform.position.y, _gameObject[j].transform.position.z);
                        transform.LookAt(targetPosition);
                        _head.transform.LookAt(_gameObject[j].transform);
                        _gun.transform.LookAt(_gameObject[j].transform);
                    }
                    else if(_enamyDist.Min() > _range && Vector3.Distance(transform.position, _gameObject[j].transform.position) == _enamyDist.Min())
                    { 
                        _head.transform.LookAt(_defaultView.transform.position);
                        _gun.transform.LookAt(_defaultView.transform.position);
                        Vector3 targetPosition = new Vector3(_gameObject[j].transform.position.x, transform.position.y, _gameObject[j].transform.position.z);
                        
                    }
                }
            }
        }
    }
 
    void Move()
    {
        if(rb.transform.position != newTarget.transform.position)
        {
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, newTarget.transform.position, _speed * Time.deltaTime);
            
        }
    }

    void GameOver()
    {
        if (_heathPlayer <= 0)
        {
            _heathPlayer = 0;
            if (_heathPlayer == 0)
            {
                if(!_gameOver)
                {
                    _writeToFile.Http();
                    Debug.Log("Вы погибли");
                    _gameOver = true;
                }
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
            Debug.Log("Пока нет урона");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == newTarget.gameObject)
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

        //Debug.Log("Коснулся");
        _isGround = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Не косается");
        _isGround = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }  
}
