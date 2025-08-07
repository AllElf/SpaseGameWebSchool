using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _bulletTransform;
    [SerializeField] float _speedBullet;
    [SerializeField] float _timeSpawn;
    [SerializeField] BeamAction _beamAction;
    [SerializeField] AudioSource _audioSourceBlaster;
    [SerializeField] GameObject bullet;
    

    private void Start()
    {
        _bulletTransform = GameObject.Find("GoalLineMobileBeamAction").GetComponent<Transform>();
        _beamAction = GameObject.Find("GoalLineMobileBeamAction").GetComponent<BeamAction>();
        StartCoroutine(Shoot());
        _audioSourceBlaster = GameObject.Find("Blaster").GetComponent<AudioSource>();
        _audioSourceBlaster.Stop();
    }
    private void FixedUpdate()
    {
        if (_beamAction._aim != "Враг на прицеле")
        {
            _bullet = null;
        }
        else if (_beamAction._aim == "Враг на прицеле")
        {
            _bullet = Resources.Load<GameObject>("Bullet");
        }
    }
    IEnumerator Shoot()
    {
        while(true)
        {
            if(_beamAction._aim == "Враг на прицеле")
            {
                SpawnBullet();
                yield return new WaitForSeconds(_timeSpawn);
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        } 
    }
    public void SpawnBullet()
    {
        //GameObject bullet;
        Rigidbody rb;
        bullet = Instantiate( _bullet, _bulletTransform.position, _bulletTransform.transform.rotation);
        rb = bullet.GetComponent<Rigidbody>();
        rb.AddRelativeForce(-_bullet.transform.up * _speedBullet);
        _audioSourceBlaster.Play();
        Destroy(bullet,3f);
    }
}
