using UnityEngine;

public class EnamySpider : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    GameObject _player;
    MovePoints _movePoints;
    [SerializeField] Animator _animator;
    [SerializeField] Vector3 _startPosition;
    public float _heath = 100f;
    public float _damageEnamy;
    public float _distance;
    public float _betweenDistance;
    [SerializeField] float _betweenDistanceStartPos;
    [SerializeField] float _endEnamyPosition;
    [SerializeField] float _speedEnemy;
    ListOfResources _listOfResources;
    [SerializeField] SkinnedMeshRenderer _chieldMeshFilter;
    [SerializeField] BoxCollider _boxCollider;
    [SerializeField] Rigidbody _rb;

    void Start()
    {
        _startPosition = transform.position;
        _player = GameObject.FindGameObjectWithTag("Player");
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _animator = GetComponent<Animator>();
        _listOfResources = GameObject.FindObjectOfType<ListOfResources>();
        _chieldMeshFilter = GetComponentInChildren<SkinnedMeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        DrowRay();
        Distance();
        EnamyPos();
        Damage();
    }

    void EnamyPos()
    {
        if (_endEnamyPosition > _distance)
        {
            _endEnamyPosition = _distance;
        }
    }
    void DrowRay()
    {
        _ray = new Ray(transform.position, transform.forward * _distance);
        if (Physics.Raycast(_ray, out _hit, _distance))
        {
            if (_hit.collider.tag == "Player")
            {
                Debug.DrawRay(transform.position, transform.forward * _distance, Color.green);
            }
            else if (_hit.collider.tag != "Player")
            {
                Debug.DrawRay(transform.position, transform.forward * _distance, Color.red);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * _distance, Color.red);
        }
    }

    void Distance()
    {
        _betweenDistance = Vector3.Distance(transform.position, _player.transform.position);
        _betweenDistanceStartPos = Vector3.Distance(transform.position, _startPosition);
        Visibility();
        if (_betweenDistance < _distance && _betweenDistance > _endEnamyPosition)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
           
            Vector3 targetPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            transform.LookAt(targetPosition);
            Vector3 vec = transform.position + transform.forward;
            transform.position = Vector3.MoveTowards(transform.position, vec, _speedEnemy * Time.deltaTime);
            _animator.SetBool("Stab Attack bool", false);
            _animator.SetBool("Walk Forward", true);
            _animator.SetBool("ldie", false);

        }
        else if (_betweenDistance < _endEnamyPosition - 1.5f)
        {

            Vector3 targetPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            transform.LookAt(targetPosition);
            Vector3 vec = transform.position - transform.forward;
            transform.position = Vector3.MoveTowards(transform.position, vec, _speedEnemy * Time.deltaTime);
            _animator.SetBool("Walk Forward", false);
            _animator.SetBool("Stab Attack bool", true);
            _animator.SetBool("ldie", false);

        }
        else if (_betweenDistance < 3)
        {
            _animator.SetBool("Walk Forward", false);
            _animator.SetBool("Stab Attack bool", true);
            _animator.SetBool("ldie", false);
        }
        else if (_betweenDistance > _distance && _betweenDistanceStartPos > 1f)
        {
            Vector3 targetPosition = new Vector3(_startPosition.x, transform.position.y, _startPosition.z);
            transform.LookAt(targetPosition);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speedEnemy * Time.deltaTime);
            _animator.SetBool("Stab Attack bool", false);
            _animator.SetBool("Walk Forward", true);
            _animator.SetBool("ldie", false);
            

        }
        else if(_betweenDistanceStartPos <= 1f)
        {
            _animator.SetBool("Stab Attack bool", false);
            _animator.SetBool("Walk Forward", false);
            _animator.SetBool("ldie", true);
        }
        
    }
    void Visibility()
    {
        if (_betweenDistance > _distance)
        {
            _boxCollider.enabled = false;
            _rb.useGravity = false;
            _chieldMeshFilter.enabled = false;
        }
        if (_betweenDistance < _distance)
        {
            _boxCollider.enabled = true;
            _rb.useGravity = true;
            _chieldMeshFilter.enabled = true;
        }
    }
    void Damage()
    {
        if (_heath <= 0)
        {
            GameObject _resurces;
            _resurces = Instantiate(_listOfResources._resourceObject, transform.position, transform.rotation);
            _resurces.name = _listOfResources._resourceObject.name;
            _listOfResources.Corutines();
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distance);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _heath -= _movePoints._damagePlayer;
        }
    }

}
