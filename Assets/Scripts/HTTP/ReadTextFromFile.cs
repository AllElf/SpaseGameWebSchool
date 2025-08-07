using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReadTextFromFile : MonoBehaviour
{
    [SerializeField][Multiline][TextArea] string textFromURL;
    [SerializeField] Text _text;
    private void Start()
    {
        StartCoroutine(GetRequest());
    }
    public void Get()
    {
        StartCoroutine(GetRequest());
    }
    public void Clear()
    {
        StartCoroutine(GetClear());
    }

    IEnumerator GetRequest()
    {
        // URL адрес файла, который нужно прочитать
        string url = "https://sehriyospace.uz/Unity/Test/data.txt";

        // Создаем UnityWebRequest для GET запроса
        UnityWebRequest www = UnityWebRequest.Get(url);

        // Отправляем запрос и ожидаем его завершения
        yield return www.SendWebRequest();

        // Проверяем наличие ошибок
        if (www.result != UnityWebRequest.Result.Success)
        {
            // Если есть ошибка, выводим ее в консоль
            Debug.LogError("Failed to read text from URL: " + www.error);
            StopCoroutine(GetRequest());
        }
        else
        {
            // Если запрос успешен, получаем текстовые данные из ответа
            textFromURL = www.downloadHandler.text;
            _text.text = www.downloadHandler.text;
            StopCoroutine(GetRequest());
            //// Выводим полученные данные в консоль
            ////Debug.Log("Text from URL: " + textFromURL);

            //// Можно обрабатывать данные дальше, например, разбив на строки
            //string[] lines = textFromURL.Split('\n');
            //foreach (string line in lines)
            //{
            //    Debug.Log(line);
            //}
        }
    }
    IEnumerator GetClear()
    {
        // URL адрес файла, который нужно прочитать
        string url = "https://sehriyospace.uz/Unity/Test/?Role=Admin&Command=Clear";

        // Создаем UnityWebRequest для GET запроса
        UnityWebRequest www = UnityWebRequest.Get(url);

        // Отправляем запрос и ожидаем его завершения
        yield return www.SendWebRequest();

        // Проверяем наличие ошибок
        if (www.result != UnityWebRequest.Result.Success)
        {
            // Если есть ошибка, выводим ее в консоль
            Debug.LogError("Failed to read text from URL: " + www.error);
            StopCoroutine(GetClear());
        }
        else
        {
            Debug.Log("Text from URL: " + textFromURL);
            StopCoroutine(GetClear());
        }
    }
}