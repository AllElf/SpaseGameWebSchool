using UnityEngine;

public class A_Hotbed_Of_Enemies : MonoBehaviour
{
    [SerializeField] float _health = 500;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _health -= 10f;
            if(_health <= 0)
            {
                _health = 0;
                Destroy(gameObject);
            }
        }
    }
}
