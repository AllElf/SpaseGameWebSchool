using UnityEngine;

public class StarTrigger : MonoBehaviour
{
    [SerializeField] StarCount starCount;

    private void Start()
    {
        starCount = GameObject.FindObjectOfType<StarCount>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            starCount.countStar++;
            if(starCount.sourceStare != null) { starCount.sourceStare.Play(); }
            Destroy(gameObject);
        }
        else { Destroy(gameObject); }
    }
}
