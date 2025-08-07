using UnityEngine;

public class TheFlyingEnemy : MonoBehaviour
{
    GameObject _player;
    MovePoints _movePoints;
    [SerializeField] Vector3 _startPosition;
    [SerializeField] ParticleSystem _particleSystem;
    public float _heath = 100f;
    public float _damageEnamy;
    public float _distance;
    public float _betweenDistance;
    [SerializeField] float _endEnamyPosition;
    [SerializeField] float _speedEnemy;
    ListOfResources _listOfResources;
    [SerializeField] SphereCollider _sphereCollider;
    

    void Start()
    {
        
        _startPosition = transform.position;
        _player = GameObject.FindGameObjectWithTag("PointTheFlyingEnemy");
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _particleSystem = GetComponent<ParticleSystem>();
        _listOfResources = GameObject.FindObjectOfType<ListOfResources>();
        _sphereCollider = GetComponent<SphereCollider>();
    }
    void FixedUpdate()
    {
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

    void Distance()
    {
        _betweenDistance = Vector3.Distance(transform.position, _player.transform.position);
        if (_betweenDistance < _distance && _betweenDistance > _endEnamyPosition)
        {
            _particleSystem.Play();
            _sphereCollider.enabled = true;
            transform.LookAt(_player.transform);
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speedEnemy * Time.deltaTime);
        }
        else if (_betweenDistance < _endEnamyPosition - 1.5f)
        {

            transform.LookAt(_player.transform);
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speedEnemy * Time.deltaTime);
        }
        else if (_betweenDistance > _distance)
        {
            _particleSystem.Stop();
            _sphereCollider.enabled = false;
            Vector3 targetPosition = new Vector3(_startPosition.x, transform.position.y, _startPosition.z);
            transform.LookAt(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speedEnemy * Time.deltaTime);

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
