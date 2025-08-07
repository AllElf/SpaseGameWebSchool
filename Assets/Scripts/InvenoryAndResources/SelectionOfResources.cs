using UnityEngine;
using UnityEngine.UI;

public class SelectionOfResources : MonoBehaviour
{
    [SerializeField] Inventory _inventory;

    private void Start()
    {
        _inventory = GameObject.FindObjectOfType<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Resource")
        {
            _inventory._resourceName = other.name;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Resource")
        {
            _inventory._resourceName = collision.collider.name;
            _inventory._image = collision.gameObject.GetComponent<Image>().sprite;
            _inventory.Clone();
            Destroy(collision.gameObject);
        }
    }
}
