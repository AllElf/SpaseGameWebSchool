using System.Linq;
using UnityEngine;


public class Raldus : MonoBehaviour
{
    [SerializeField] float _range;
    [SerializeField] GameObject[] _gameObject;
    [SerializeField] float[] _enamyDist;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
    void SearchEnamy()
    {
        _gameObject = GameObject.FindGameObjectsWithTag("Enamy");
        _enamyDist = new float[_gameObject.Length];
        for (int i = 0; i < _gameObject.Length; i++)
        {
            _enamyDist[i] = Vector3.Distance(transform.position, _gameObject[i].transform.position);

            for (int j = 0; j < _gameObject.Length; j++)
            {
                if (_enamyDist.Min() < _range && Vector3.Distance(transform.position, _gameObject[j].transform.position) == _enamyDist.Min())
                {
                    transform.LookAt(_gameObject[j].transform);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        SearchEnamy();
        
    }
}
