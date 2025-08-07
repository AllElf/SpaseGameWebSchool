using UnityEngine;

[CreateAssetMenu(fileName = "OxygenTankItem Item", menuName = "Inventory/Items/new OxygenTankItem Item")] // Строка для создания ScriptableObject как отдельные объекты
public class OxygenTankItem : ItemScriptableObject
{
    public float healAmount;// Восстановление здоровья с помощбю еды

    private void Awake() // До начала игры он определит какого типа наш объект
    {
        itemType = ItemType.OxygenTankItem;// itemType равет еде

    }
}