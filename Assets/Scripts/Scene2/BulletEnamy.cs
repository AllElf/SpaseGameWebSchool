using UnityEngine;

public class BulletEnamy : MonoBehaviour
{
    [SerializeField] string _tag = "Player";
    [SerializeField] float _damage = 5;
    [SerializeField] MovePoints _movePoints;

    private void Start()
    {
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == _tag)
        {
            _movePoints._heathPlayer -= _damage;
        }
    }
}
