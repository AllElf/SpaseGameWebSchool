using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] EnamyRotation _EnamyRotation;
    [SerializeField] ParticleSystem _particles;
    [SerializeField] ParticleSystem _playerBlood;
    [SerializeField] GameObject _gameObject;
    [SerializeField] MovePoints _movePoints;
    [SerializeField] AudioSource _audioSourceBoom;
    [SerializeField] AudioSource _audioSourceBlood;
    public float _damageBomb;

    private void Start()
    {
        _EnamyRotation = GetComponent<EnamyRotation>();
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _particles.Stop();
        _playerBlood = GameObject.Find("Blood Splash").GetComponent<ParticleSystem>();
        _playerBlood.Stop();
        _audioSourceBoom = GameObject.Find("Boom").GetComponent<AudioSource>();
        _audioSourceBlood = GameObject.Find("Blood").GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if(_EnamyRotation._heath == 0)
        {
            _particles.Play();
            _audioSourceBoom.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _particles.Play();
            _audioSourceBoom.Play();
            _audioSourceBlood.Play();
            gameObject.GetComponent<EnamyRotation>().enabled = false;
            _movePoints._heathPlayer -= _damageBomb;
            if (_gameObject != null)
            {
                Destroy(_gameObject);
            }
            if (_particles != null) { _playerBlood.Play(); }
            Destroy(gameObject, 0.4f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            _particles.Play();
            _audioSourceBoom.Play();
            _audioSourceBlood.Play();
            gameObject.GetComponent<EnamyRotation>().enabled = false;
            _movePoints._heathPlayer -= _damageBomb;
            Destroy(gameObject, 0.4f);
            if (_gameObject != null)
            {
                Destroy(_gameObject);
            }
            if (_particles != null) { _playerBlood.Play(); }
            
        }
    }
}
