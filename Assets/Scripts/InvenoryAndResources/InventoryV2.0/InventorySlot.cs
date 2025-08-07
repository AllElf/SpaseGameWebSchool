using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour // Скрипт для изменения параметров слота
{
    public ItemScriptableObject item; // указываем тип
    public int amount; // Указываем количество
    public bool isEmpty = true; // переменная отвечающая что объект Пустышка или нет?
    public GameObject iconGO; // Параметр иконки объекта
    public Text itemAmountText;
    [SerializeField] GameObject thisPrefab;
    [SerializeField] GameObject _releasePoint;
    public GameObject _resources;
    InventoryManager inventoryManager;
    [SerializeField] int index;


    private void Start()
    {
        inventoryManager = GameObject.Find("ScriptManager").GetComponent<InventoryManager>();
        _releasePoint = GameObject.FindGameObjectWithTag("ReleasePoint");
        iconGO = transform.GetChild(0).gameObject;
        itemAmountText = transform.GetChild(1).GetComponent<Text>();
        StartCoroutine(UpdateCorrutite());

    }
    //private void FixedUpdate()
    //{
    //    //index = transform.GetSiblingIndex(); // Узнаём какой по счёту(Индекс) дочерний объект у родителя
    //    if (item != null)
    //    {
    //        _resources = item.itemPrefab;
    //    }
    //}
    IEnumerator UpdateCorrutite()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (item != null)
            {
                _resources = item.itemPrefab;
            }

        }
    }
    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }
    public void AmountMinus()
    {
        if (amount > 0)
        {
            amount--;
            transform.GetChild(1).GetComponent<Text>().text = amount.ToString();
            Instantiate(_resources, _releasePoint.transform.position, _releasePoint.transform.rotation);
            if (amount == 0)
            {
                transform.GetChild(1).GetComponent<Text>().text = "";
                item = null;
                iconGO.GetComponent<Image>().sprite = null;
                iconGO.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                GameObject slot;
                slot = Instantiate(thisPrefab, inventoryManager.InventoryPanel.position, inventoryManager.InventoryPanel.rotation, inventoryManager.InventoryPanel);
                if (slot.GetComponent<InventorySlot>() != null) // Если родительский объект InventoryPanel имеет дочерние объекты которые имеют компонент InventorySlot то выполняем действия ниже
                {
                    inventoryManager.slots.Add(slot.GetComponent<InventorySlot>()); // Добавляем компонент InventorySlot в лист под названием slots
                    slot.GetComponent<InventorySlot>().isEmpty = true;
                    slot.GetComponent<InventorySlot>()._resources = null;
                    slot.transform.SetAsFirstSibling();// Перемещаем позицию дочернего объекта вначало списка
                    inventoryManager.slots.RemoveAt(inventoryManager.slots.Count - 1);// Удаляем последний объект из листа
                    inventoryManager.slots.Insert(0, slot.GetComponent<InventorySlot>()); // Заменяем нулевой элемент листа этим - slot.GetComponent<InventorySlot>()
                    inventoryManager.slots.Remove(gameObject.GetComponent<InventorySlot>()); // Удаляем объект из листа
                }
                Destroy(gameObject);
            }
        }
        
            
        
    }
}
