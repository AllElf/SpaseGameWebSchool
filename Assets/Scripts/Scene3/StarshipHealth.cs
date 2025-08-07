using UnityEngine;
using UnityEngine.UI;

public class StarshipHealth : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] ParticleSystem _particleSystem;
    BulletStarshipSpawn _bulletStarshipSpawn;
    public float healthSparship = 1f;
    [SerializeField] WeaponsImprovement weaponsImprovement;
    [SerializeField] AudioSource[] AudioSource;
    [SerializeField] GameObject gameOver;

    [System.Obsolete]
    private void Start()
    {
        if (gameOver != null) { gameOver.SetActive(false); }
        _bulletStarshipSpawn = GameObject.FindObjectOfType<BulletStarshipSpawn>();
        _particleSystem.Stop();
    }
    private void FixedUpdate()
    {
        image.fillAmount = healthSparship;
        if(healthSparship <= 0)
        {
            healthSparship = 0;
            if (gameOver != null) { gameOver.SetActive(true); }
        }
        else if (healthSparship >= 1)
        {
            healthSparship = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Ambulance")
        {
            healthSparship += 0.34f; if(healthSparship > 1f) { healthSparship = 1f; }
            if (AudioSource[1] != null) { AudioSource[1].Play(); }
        }
        else if(other.tag == "Improvements")
        {
            if (weaponsImprovement.actived) { _bulletStarshipSpawn._speedSpawnBullet -= 0.1f; }
            if(weaponsImprovement != null) { weaponsImprovement.ActivateNextWeapon(); }
            if (AudioSource[1] != null) { AudioSource[1].Play(); }
        }
        else if (other.tag != "Bullet" && other.tag != "Ambulance" && other.tag != "Improvements" && other.tag != "Star")
        {
            healthSparship -= 0.34f; if (healthSparship < 0f) { healthSparship = 0f; }
            _bulletStarshipSpawn._speedSpawnBullet += 0.1f;
            _particleSystem.Play();
            if (weaponsImprovement != null) { weaponsImprovement.DeactivateLastWeapon(); }
            if(AudioSource[0] != null) { AudioSource[0].Play(); }
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Enamy")
    //    {
    //        healthSparship -= 0.34f; if (healthSparship < 0f) { healthSparship = 0f; }
    //    }
    //}
}
