using System.Collections;
using UnityEngine;

public class DestroqPointer : MonoBehaviour
{
    [SerializeField] float _seconds;

    private void Start()
    {
        StartCoroutine(Destroy());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }    
    }
    private void FixedUpdate()
    {
        if(_seconds >= 10) 
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Destroy()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            _seconds++;
        }
    }
}
