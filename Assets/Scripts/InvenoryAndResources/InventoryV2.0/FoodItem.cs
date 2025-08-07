using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/new Food Item")] // Строка для создания ScriptableObject как отдельные объекты
public class FoodItem : ItemScriptableObject
{
    public float healAmount;// Восстановление здоровья с помощбю еды

    //private void Awake() // До начала игры он определит какого типа наш объект
    //{
    //    itemType = ItemType.Food;// itemType равет еде
        
    //}
}
