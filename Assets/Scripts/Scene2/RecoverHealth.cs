using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    [SerializeField] float _health = 500;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<MovePoints>()._heathPlayer += _health;
            Destroy(gameObject);
        }
    }
}
