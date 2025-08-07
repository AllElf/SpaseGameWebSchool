using UnityEngine;

[CreateAssetMenu(fileName = "Instrument Item", menuName = "Inventory/Items/new Instrument Item")] // Строка для создания ScriptableObject как отдельные объекты
public class InstrumentItem : ItemScriptableObject
{
    public float healAmount;// Восстановление здоровья с помощбю еды

    private void Awake() // До начала игры он определит какого типа наш объект
    {
        itemType = ItemType.Instrument;// itemType равет еде
        
    }
}