using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WriteToFileFlying : MonoBehaviour
{
    [SerializeField] Scene2Controller _scene2Controller;
    public string _personalDataTwo;

    private void Awake()
    {
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
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
        string _studentDate = _scene2Controller._personalDataOne + "\nМежпланетный перелёт Баллы: " + _scene2Controller._counsTwoScene.ToString() + "\n";
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
