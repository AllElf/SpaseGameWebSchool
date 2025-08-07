using UnityEngine;

public class ContactInteraction : MonoBehaviour
{
    [SerializeField] InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Item>() != null)
        {
            inventoryManager.AddItem(collision.gameObject.GetComponent<Item>().item, collision.gameObject.GetComponent<Item>().amount); // Вызываем и передаём два параметра в item и amount которые в скрипте Item у объекта с которым соприкоснулись
            Destroy(collision.gameObject); // Удаляем объект с которым соприкоснулись
        }
    }
}
