using UnityEngine;

public class EnamyRotation : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;
    GameObject _player;
    Rigidbody _body;
    MovePoints _movePoints;
    [SerializeField] Vector3 _startPosition;
    public float _heath = 100f;
    public float _damageEnamy;
    public float _distance;
    public float _betweenDistance;
    [SerializeField] float _endEnamyPosition;
    [SerializeField] float _speedEnemy;
    [SerializeField] MeshRenderer[] _chieldMeshFilter;
    [SerializeField] ParticleSystem[] _chieldParticleSystem;
    [SerializeField] SphereCollider _sphereCollider;
    [SerializeField] Rigidbody _rb;



    void Start()
    {
        _startPosition = transform.position;
        _player = GameObject.FindGameObjectWithTag("Player");
        _body = GetComponent<Rigidbody>();
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _chieldMeshFilter = gameObject.GetComponentsInChildren<MeshRenderer>();
        _chieldParticleSystem = gameObject.GetComponentsInChildren<ParticleSystem>();
        _rb = GetComponent<Rigidbody>();
        _sphereCollider = GetComponent<SphereCollider>();
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
        if(_endEnamyPosition > _distance)
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
            else if(_hit.collider.tag != "Player")
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
        if ( _betweenDistance < _distance && _betweenDistance > _endEnamyPosition )
        {
            //gameObject.GetComponent<MeshRenderer>().enabled = true;
            for (int j = 0; j < _chieldMeshFilter.Length; j++)
            {
                _chieldMeshFilter[j].enabled = true;
            }
            _rb.useGravity = true;
            _sphereCollider.enabled = true;
            _chieldParticleSystem[1].Play();
            Vector3 targetPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            transform.LookAt(targetPosition);
            Vector3 vec = transform.position + transform.forward;
            _body.transform.position = Vector3.MoveTowards(_body.transform.position, vec, _speedEnemy * Time.deltaTime);
        }
        else if (_betweenDistance < _endEnamyPosition-1.5f)
        {
            
            Vector3 targetPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            transform.LookAt(targetPosition);
            Vector3 vec = transform.position - transform.forward;
            _body.transform.position = Vector3.MoveTowards(_body.transform.position, vec, _speedEnemy * Time.deltaTime);
        }
        else if (_betweenDistance > _distance)
        {
            Vector3 targetPosition = new Vector3(_startPosition.x, transform.position.y, _startPosition.z);
            transform.LookAt(targetPosition);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            for(int j = 0;  j < _chieldMeshFilter.Length; j++) 
            {
                _chieldMeshFilter[j].enabled = false;
            }
            _rb.useGravity = false;
            _sphereCollider.enabled = false;
            _chieldParticleSystem[1].Stop();
            
            _body.transform.position = Vector3.MoveTowards(_body.transform.position, _startPosition, _speedEnemy * Time.deltaTime);

        }
    }
    void Damage()
    {
        if (_heath <= 0)
        {
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
        if(other.tag == "Bullet")
        {
            _heath -= _movePoints._damagePlayer;
        }
    }

}
