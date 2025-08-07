using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] string _tag = "Enamy";
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == _tag)
        {
            Destroy(gameObject);
        }
    }
}
