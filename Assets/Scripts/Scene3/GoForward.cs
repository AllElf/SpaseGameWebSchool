using System.Collections;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    [SerializeField] public float _speed;
    private void Start()
    {
        StartCoroutine(SPEED());
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, _speed * Time.deltaTime);
        if(transform.position.z > 5000)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    IEnumerator SPEED()
    {
        while (_speed < 65)
        {
            yield return new WaitForSeconds(1f);
            _speed += 0.5f;
            if(_speed >=65)
            {
                StopCoroutine(SPEED());
                break;
                
            }
        }
    }
}
