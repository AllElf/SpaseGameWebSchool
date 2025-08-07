using System.Collections;
using UnityEngine;

public class ParticlesChest : MonoBehaviour
{
    public ParticleSystem[] _particleSystemsChest;
    [SerializeField] Animator _animator;
    [SerializeField] float _healthChest = 10;
    [SerializeField] BoxCollider _collider;
    [SerializeField] Animator _animatorChaild;
    [SerializeField] GameObject _card;
    private void Start()
    {
        _particleSystemsChest = GetComponentsInChildren<ParticleSystem>();
        _animator = GetComponent<Animator>();
        _animatorChaild.enabled = false;
        _collider = GetComponent<BoxCollider>();
        _animator.enabled = false;
        for (int i = 0; i < _particleSystemsChest.Length; i++)
        {
            _particleSystemsChest[i].Stop();
        }
        _card.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            _healthChest -= 2.5f;
            if (_healthChest <= 0)
            {
                _healthChest = 0;
                _card.SetActive(true);
                gameObject.tag = "Empty";
                Destroy(_collider);
                _animatorChaild.enabled = true;
            }
        }
    }
    public void DeleteObject()
    {
        
        for (int i = 0; i < _particleSystemsChest.Length; i++)
        {
            _particleSystemsChest[i].Play();
        }
        _animator.enabled = true;
        StartCoroutine(Del());
    }

    IEnumerator Del()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
