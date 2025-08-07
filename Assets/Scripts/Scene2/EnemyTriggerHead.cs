using UnityEngine;

public class EnemyTriggerHead : MonoBehaviour
{
    MeshRenderer _meshRendererHead;

    private void Start()
    {
        _meshRendererHead = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enamy")
        {
            _meshRendererHead.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enamy")
        {
            _meshRendererHead.enabled = true;
        }
    }
}
