using UnityEngine;

public class BulletStarship : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float _speedComet;
    [SerializeField] AudioSource _audioSourceBoom;

    private void Start()
    {
        if(GameObject.Find("Boom"))
        {
            _audioSourceBoom = GameObject.Find("Boom").GetComponent<AudioSource>();
        }
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        
        if(gameObject.tag == "Bullet")
        {
            rb.AddRelativeForce(rb.transform.forward * _speedComet);
        }
        else
        {
            rb.AddRelativeForce(-rb.transform.forward * _speedComet);
        }
        Destroy(gameObject,2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enamy" || other.tag == "Planet")
        {
            if(GetComponent<ParticleSystem>() != null)
            {
                GetComponent<ParticleSystem>().Play();  
            }
            if(gameObject.tag == "Bullet") { _audioSourceBoom.Play(); }  
            Destroy(gameObject, 1f);
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
