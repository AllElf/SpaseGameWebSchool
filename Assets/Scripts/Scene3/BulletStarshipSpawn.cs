using System.Collections;
using UnityEngine;

public class BulletStarshipSpawn : MonoBehaviour
{
    [System.Serializable]
    public class SpawnPoint
    {
        public Transform spawnTransform;
        public bool isActive = true;
        public AudioSource audioSourceBlaster;
        public GameObject bulletPrefab;
        public GameObject gunObject; // 👈 Новый объект — пушка
    }

    [SerializeField] private SpawnPoint[] spawnPoints;
    [SerializeField] public float _speedSpawnBullet = 0.5f;

    private void Start()
    {
        foreach (var point in spawnPoints)
        {
            if (point.audioSourceBlaster == null && point.spawnTransform != null)
            {
                point.audioSourceBlaster = point.spawnTransform.GetComponent<AudioSource>();
            }
        }

        StartCoroutine(SpawnBulletsRoutine());
    }

    private void FixedUpdate()
    {
        _speedSpawnBullet = Mathf.Clamp(_speedSpawnBullet, 0.1f, 0.5f);
    }

    IEnumerator SpawnBulletsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_speedSpawnBullet);

            foreach (var point in spawnPoints)
            {
                // 🔒 Проверка активности пушки
                if (!point.isActive || point.spawnTransform == null || point.bulletPrefab == null) continue;
                if (point.gunObject != null && !point.gunObject.activeInHierarchy) continue;

                GameObject bullet = Instantiate(
                    point.bulletPrefab,
                    point.spawnTransform.position,
                    point.spawnTransform.rotation
                );

                bullet.name = "BulletStarship_" + point.bulletPrefab.name;

                if (point.audioSourceBlaster != null)
                {
                    point.audioSourceBlaster.Play();
                }
            }
        }
    }
}