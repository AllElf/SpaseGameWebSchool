using UnityEngine;

public class FindCamera : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }

}
