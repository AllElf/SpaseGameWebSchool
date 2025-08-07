using UnityEngine;

public class SpeedEffects : MonoBehaviour
{
    [SerializeField] GoForward goForwardScript;
    [SerializeField] GameObject[] particlesObjects;
    [SerializeField] ParticleSystem[] particles;
    [SerializeField] bool _enableTurboSpeed;
    [SerializeField] bool _enableTurboFire;
    [SerializeField] AudioSource _audioSourceEngine;
    [SerializeField] AudioSource _audioSourceEngineTwo;


    private void Start()
    {
        _enableTurboSpeed = false;
        if (particles != null)
        {
            for (int i = 0; i < particlesObjects.Length; i++)
            {
                particlesObjects[i].SetActive(true);
            }
        }
    }
    private void FixedUpdate()
    {
        if (!_enableTurboSpeed && goForwardScript._speed >= 5f)
        {
            if (particles != null)
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    if (particles[i].tag == "TurboSpeed")
                    particles[i].Play();
                    if (_audioSourceEngine != null) { _audioSourceEngine.Play(); }
                    _enableTurboSpeed = true;
                }
            }
        }
        if (!_enableTurboFire && goForwardScript._speed >= 15f)
        {
            if (particles != null)
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    if (particles[i].tag == "TurboFire")
                        particles[i].Play();
                    if (_audioSourceEngineTwo != null) { _audioSourceEngineTwo.Play(); }
                    _enableTurboFire = true;
                    Destroy(GetComponent<SpeedEffects>());
                }
            }
        }
    }
}
