using UnityEngine;

[CreateAssetMenu(fileName = "Battary Item", menuName = "Inventory/Items/new Battary Item")] // Строка для создания ScriptableObject как отдельные объекты
public class BattaryItem : ItemScriptableObject
{
    public float healAmount;// Восстановление здоровья с помощбю еды

    //private void Awake() // До начала игры он определит какого типа наш объект
    //{
    //    itemType = ItemType.Battary;// itemType равет еде
        
    //}
}