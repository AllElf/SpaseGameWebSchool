using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speedBullet;

    void FixedUpdate()
    {

        if (gameObject.tag == "Bullet")
        {
            rb.AddRelativeForce(rb.transform.forward * speedBullet);
        }
        else
        {
            rb.AddRelativeForce(-rb.transform.forward * speedBullet);
        }
    }
}
