using UnityEngine;

public class AChestWithImprovements : MonoBehaviour
{
    [SerializeField] float _healthChest = 10;
    [SerializeField] BoxCollider _collider;
    [SerializeField] Animator _animator;
    
    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        //transform.GetChild(0).gameObject.SetActive(false);
        _animator.enabled = false;
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            _healthChest -= 2.5f;
            if(_healthChest <= 0 )
            {
                _healthChest = 0;
                Destroy(_collider);
                _animator.enabled = true;
            }
        }
    }
    public void IsOpened()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
