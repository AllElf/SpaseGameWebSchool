using System.Collections;
using UnityEngine;

public class TheFlyingEnemyGun : MonoBehaviour
{
    GameObject _player;
    [SerializeField] string _enemyBulletName = "Bullet";
    [SerializeField] GameObject _bullet;
    [SerializeField] float _speedAttack;
    [SerializeField] float _addForceBullet;
    [SerializeField] float _betweenDistance;
    [SerializeField] float _distance;
    void Start()
    {
        _bullet = Resources.Load<GameObject>(_enemyBulletName);
        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Attack());
    }
    private void FixedUpdate()
    {
        transform.LookAt(_player.transform.position);
        _betweenDistance = Vector3.Distance(transform.position, _player.transform.position);
    }
    IEnumerator Attack()
    {
        while (true)
        {
            if(_betweenDistance <= _distance) 
            {
                GameObject bullet;
                Rigidbody rb;
                bullet = Instantiate(_bullet, transform.position, transform.transform.rotation);
                rb = bullet.GetComponent<Rigidbody>();
                rb.AddRelativeForce(-_bullet.transform.up * _addForceBullet);
                Destroy(bullet, 5f);
                yield return new WaitForSeconds(_speedAttack);
            }
            else
            {
                yield return new WaitForSeconds(_speedAttack);
            }
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distance);
    }
}
