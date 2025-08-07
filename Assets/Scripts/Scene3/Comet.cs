using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float _speedComet;
    [SerializeField] float _secondDestroy = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddRelativeForce(-rb.transform.forward * _speedComet);
        Destroy(gameObject, _secondDestroy);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject);
    //}

    
}
