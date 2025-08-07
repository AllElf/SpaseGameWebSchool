using System.Collections;
using UnityEngine;

public class ChargeDetonator : MonoBehaviour
{
    [Header("Detonation Settings")]
    public bool detonate = false;
    public float blastRadius = 5f;
    public string targetTag = "Enemy";
    public float secondDetonate;
    public float secondDestroy;

    [Header("Explosion Effect")]
    public AudioSource audioSource;
    [SerializeField] string tagAudioBullet = "Boom";
    [SerializeField] ParticleSystem effect;

    [Header("Debug Visualization")]
    public Color gizmoColor = new Color(1f, 0.3f, 0f, 0.4f); // Orange semi-transparent

    private void Start()
    {
        if (gameObject.tag == "Bullet") { audioSource = GameObject.Find(tagAudioBullet).GetComponent<AudioSource>(); Destroy(gameObject, 3f); }
    }
    void Update()
    {
        if (detonate)
        {
            Detonate();
            detonate = false; // сбрасываем флаг, чтобы можно было снова вызвать
        }
    }

    void Detonate()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag(targetTag))
            {
                Destroy(hit.gameObject);
            }
        }

        if (audioSource != null)
        {
            audioSource.Play();
            if(effect != null) {  effect.Play(); }
        }
    }

    IEnumerator DetonateBullet()
    {
        detonate = true;
        yield return new WaitForSeconds(secondDestroy);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, blastRadius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Bullet")
        {
            if(other.tag != "Player")
            {
                StartCoroutine(DetonateBullet());
            }  
        }
    }
}