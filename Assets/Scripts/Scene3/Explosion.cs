using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        _particleSystem.Play();
    }
}
