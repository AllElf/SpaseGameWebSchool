using UnityEngine;

public enum ItemType {Default/*дефолтный объект*/, Food/*объект еды*/, Weapon/*объект оружия*/, Instrument/*объект инструментария*/, Battary, OxygenTankItem } // типы объектов
public class ItemScriptableObject : ScriptableObject
{
   
    public string itemName; // Имя объектов
    public int maximumAmount; // Максимальное количество стаков объектов
    public GameObject itemPrefab; // объекто префаб
    public Sprite icon;
    public ItemType itemType; // переменная для типов объектов которые мы указали выше класса
    public string itemDescription; // Для описания объекта
}
