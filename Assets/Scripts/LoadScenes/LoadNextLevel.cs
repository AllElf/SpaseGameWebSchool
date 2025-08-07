using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField] CanvasQuestionScript _canvasQuestionScript;
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _starShip;
    PersonalData _personalData;
    [SerializeField] float _questionCounts = 10f;
    [SerializeField] string _nameScene = "NextSceneLevel";
    [SerializeField] Text _textCountCard;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        if (GameObject.FindGameObjectsWithTag("CardQuestion") != null)
        {
            _questionCounts = GameObject.FindGameObjectsWithTag("CardQuestion").Length;
        }
        if (GetComponent<CanvasQuestionScript>() != null)
        {
            _canvasQuestionScript = GetComponent<CanvasQuestionScript>();
        }
        if(GetComponent<PersonalData>() != null)
        {
            _personalData = GetComponent<PersonalData>();
        }
        
    }

    void SearshCard()
    {
        if (GameObject.FindGameObjectsWithTag("CardQuestion") != null)
        {
            _questionCounts = GameObject.FindGameObjectsWithTag("CardQuestion").Length;
        }
        else if (GameObject.FindGameObjectsWithTag("CardQuestion") == null)
        {
            _questionCounts = 0;
        }
        if (_questionCounts == 0)
        {
            _starShip.GetComponent<BoxCollider>().isTrigger = true;
        }
        else if (_questionCounts != 0)
        {
            _starShip.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
    private void FixedUpdate()
    {
        _textCountCard.text = "Осталось ящиков " + _questionCounts.ToString();
        SearshCard();
        //if (_canvasQuestionScript._countScores >= _questionCounts)
        //{
        //    _starShip.GetComponent<BoxCollider>().isTrigger = true;
        //    /*GameManager.Instance.dataToTransfer = _personalData._studentPersonalData;*/ // Передаём персональные данные в скрипт GameManager в переменную Instance
        //    /*GameManager.Instance.scoreToTransfer = _personalData.Scores;*/ // Передаём заработанные очки в скрипт GameManager в переменную scoreToTransfer
        //    /*Load();*/// Загружаем следующую сцену "Примечание: на следующей сцене обязятельно должен быть скрипт Scene2Controller"
        //}
        //else
        //{
        //    _starShip.GetComponent<BoxCollider>().isTrigger = false;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Вошёл!");
            Load();
        }
    }
    public void Load()
    {
        //GameManager.Instance.dataToTransfer = _personalData._studentPersonalData;
        SceneManager.LoadScene(_nameScene);
    }
}
