using System.Collections;
using UnityEngine;

public class BulletEnemySpawn : MonoBehaviour
{
    [SerializeField] Transform _spawnBullet;
    [SerializeField] GameObject _bullet;

    private void Start()
    {
        _spawnBullet = transform;
        StartCoroutine(Atack());
    }
    IEnumerator Atack()
    {
        for (int i = 0; i < 4f; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject enemyBullen = Instantiate(_bullet, transform.position, transform.rotation);
        }
    }
}
