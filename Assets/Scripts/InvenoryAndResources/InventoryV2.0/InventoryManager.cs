using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform InventoryPanel; // панель со слотами
    public List<InventorySlot> slots = new List<InventorySlot>(); // лист объектов со скриптами InventorySlot

    [SerializeField] GameObject _canvasInventory;
    [SerializeField] Transform _inventoryPointTrue;
    [SerializeField] Transform _inventoryPointFalse;


    private void Start()
    {
        InventoryPanel = GameObject.Find("PanelContainer").transform;
        _canvasInventory = GameObject.Find("Canvas (Inventory)");
        _inventoryPointTrue = GameObject.Find("PointInventoryTrue").transform;
        _inventoryPointFalse = GameObject.Find("PointInventoryFalse").transform;
        for (int i = 0; i < InventoryPanel.childCount; i++) // вычисляем сколько дочерних объектов в нашей панели со слотами
        {
            if (InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null) // Если родительский объект InventoryPanel имеет дочерние объекты которые имеют компонент InventorySlot то выполняем действия ниже
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>()); // Добавляем компонент InventorySlot в лист под названием slots
            }
        }
    }
    public void InventoryButtonTrue()
    {
        _canvasInventory.transform.position = _inventoryPointTrue.position;
    }
    public void InventoryButtonFalse()
    {
        _canvasInventory.transform.position = _inventoryPointFalse.position;
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots) //перебираем лист со слотами
        {
            if (slot.item == _item && slot.amount == _amount) // Если item - "он указывается в скрипте InventorySlot" у слота равен _item который был создан в этом методе то 
            {
                if (slot.amount <= _item.maximumAmount)
                {
                    slot.amount += _amount; // к количеству слотов прибовляем количество указанное в этом методе
                    slot.itemAmountText.text = slot.amount.ToString();
                    slot.SetIcon(_item.icon); // Указываем какую иконку применяем в слот
                    return;
                }
                break; // останавливаем цикл
            }
        }
        foreach (InventorySlot slot in slots) //перебираем лист со слотами
        {
            if (slot.isEmpty == true) // если слот пустышка то
            {
                slot.item = _item; // создаём слот
                slot.amount = _amount; // указываем колличество
                slot.isEmpty = false;
                slot.SetIcon(_item.icon); // Указываем какую иконку применяем в слот
                slot.itemAmountText.text = _amount.ToString();
                break; // останавливаем цикл    
            }
        }
    }
}
