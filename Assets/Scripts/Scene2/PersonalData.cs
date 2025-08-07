using UnityEngine;
using UnityEngine.UI;

public class PersonalData : MonoBehaviour
{
    CanvasQuestionScript _CanvasQuestionScript;
    [SerializeField] GameObject personalPanel;
    public string _schoolName;
    public string _name;
    public string _lastName;
    public string _class;
    public float Scores;
    public string _studentPersonalData;
    Text _schoolNameText;
    Text _nameText;
    Text _lastNameText;
    Text _classText;
    public Text _personalData;
    [SerializeField] Timer _timer;

    private void Start()
    {
        personalPanel.SetActive(true);
        _CanvasQuestionScript = GameObject.FindObjectOfType<CanvasQuestionScript>();
        personalPanel = GameObject.Find("PanelStart");
        _personalData = GameObject.Find("Text (Personal data)").GetComponent<Text>();
        _schoolNameText = GameObject.Find("Text (schoolName)").GetComponent<Text>();
        _nameText = GameObject.Find("Text (Name)").GetComponent<Text>();
        _lastNameText = GameObject.Find("Text (lastName)").GetComponent<Text>();
        _classText = GameObject.Find("Text (Class)").GetComponent<Text>();
        _timer = GetComponent<Timer>();
        Time.timeScale = 0f;
    }

    private void FixedUpdate()
    {
        Scores = _CanvasQuestionScript._countScores;
        //_personalData.text = "Личные данные:\n" + "Школа " + _schoolName + "\n" + "Имя " + _name + "\n" + "Фамилия " + _lastName + "\n" + "Класс " + _class + "\n" + "Баллы " + Scores.ToString() + "\n";
        _studentPersonalData = "Личные данные:\n" + "Школа " + _schoolName + "\n" + "Имя " + _name + "\n" + "Фамилия " + _lastName + "\n" + "Класс " + _class + "\n" + "Плутон Баллы: ";
        _personalData.text = _studentPersonalData + Scores.ToString() + "\n";
    }
    public void Done()
    {
        if (_schoolNameText.text != "" && _nameText.text != "" && _lastNameText.text != "" && _classText.text != "")
        {
            Time.timeScale = 1.0f;
            _schoolName = GameObject.Find("Text (schoolName)").GetComponent<Text>().text;
            _name = GameObject.Find("Text (Name)").GetComponent<Text>().text;
            _lastName = GameObject.Find("Text (lastName)").GetComponent<Text>().text;
            _class = GameObject.Find("Text (Class)").GetComponent<Text>().text;
            personalPanel.SetActive(false);
            _timer.StartTimer();
            Debug.Log("Всё заполнено");
        }
        else
        {
            Debug.Log("Поля не заполнены");
        }
    }
}
