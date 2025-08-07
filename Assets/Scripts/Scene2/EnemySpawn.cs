using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] string _nameRandomSpawn = "RandomSpawn";
    [SerializeField] Transform[] _enemySpawn;
    [SerializeField] EnamyType[] _enamyType;
    [SerializeField] GameObject[] _enemyPrefabs;

   

    private void Start()
    {
        _enemySpawn = GameObject.Find(_nameRandomSpawn).transform.GetComponentsInChildren<Transform>();
        Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], _enemySpawn[Random.Range(1, _enemySpawn.Length)].position, _enemySpawn[Random.Range(1, _enemySpawn.Length)].rotation);
        StartCoroutine(Clone());
        
    }

    IEnumerator Clone() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(0.5f);
            _enamyType = GameObject.FindObjectsOfType<EnamyType>();
            if (_enamyType.Length < 11)
            {
                Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], _enemySpawn[Random.Range(1, _enemySpawn.Length)].position, _enemySpawn[Random.Range(1, _enemySpawn.Length)].rotation);
            }
        }
    }
}
