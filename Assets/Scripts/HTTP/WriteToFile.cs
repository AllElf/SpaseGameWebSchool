using System.Collections; // Импорт пространства имен для работы с коллекциями
using UnityEngine;        // Импорт пространства имен для работы с Unity
using UnityEngine.Networking; // Импорт пространства имен для работы с сетевыми запросами

public class WriteToFile : MonoBehaviour // Объявление класса WriteToFile, наследующего MonoBehaviour
{

    PersonalData _personalData;

    private void Awake()
    {
        _personalData = FindObjectOfType<PersonalData>();
    }
    
    // Метод для отправки HTTP-запроса
    public void Http()
    {
        // Запускаем корутину для отправки текста на сервер
        StartCoroutine(SendTextToFile());
    }

    // Корутина для отправки текста на сервер
    IEnumerator SendTextToFile()
    {
        string _studentDate = _personalData._personalData.text + "\n";
        // Создаем форму для отправки данных
        WWWForm form = new WWWForm();
        form.AddField("name", _studentDate); // Добавляем поле "name" со значением, которое хотим записать

        // Создаем объект UnityWebRequest для отправки POST-запроса на сервер
        UnityWebRequest www = UnityWebRequest.Post("https://sehriyospace.uz/Unity/Test/fromunity.php", form);

        // Отправляем запрос и ожидаем его завершения
        yield return www.SendWebRequest();

        // Проверяем наличие ошибки
        if (www.result != UnityWebRequest.Result.Success)
        {
            // Если ошибка есть, выводим сообщение об ошибке в консоль
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            // Если ошибки нет, выводим ответ сервера в консоль
            Debug.Log("Response: " + www.downloadHandler.text);
        }
        www.Dispose();
    }
}