using UnityEngine;

public class LookHead : MonoBehaviour
{
    [SerializeField] GameObject _head;
    [SerializeField] GameObject _hit;
    void Start()
    {
        _head = GameObject.Find("HeadSolder");
        _hit = GameObject.Find("_hit");
    }

    
    void FixedUpdate()
    {
        _head.transform.LookAt(_hit.transform.position);
    }
}
