using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    [SerializeField] EnamySpider _EnamySpider;
    [SerializeField] ParticleSystem _playerBlood;
    [SerializeField] MovePoints _movePoints;
    [SerializeField] AudioSource _audioSourceBlood;
    public float _damageSpider;

    private void Start()
    {
        _EnamySpider = GetComponentInParent<EnamySpider>();
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _playerBlood = GameObject.Find("Blood Splash").GetComponent<ParticleSystem>();
        _playerBlood.Stop();
        _audioSourceBlood = GameObject.Find("Blood").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerBlood.Play();
            _audioSourceBlood.Play();
            _movePoints._heathPlayer -= _damageSpider;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            _playerBlood.Play();
            _audioSourceBlood.Play();
            _movePoints._heathPlayer -= _damageSpider;
        }
    }
}
