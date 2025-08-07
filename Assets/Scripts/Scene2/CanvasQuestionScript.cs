using UnityEngine;
using UnityEngine.UI;

public class CanvasQuestionScript : MonoBehaviour
{
    public float _countScores;
    public bool _enabledCanvas = false;
    public GameObject _canvasQuestion;
    [SerializeField] Text _questionText;
    void Start()
    {
        _enabledCanvas = false;
        _questionText = GameObject.Find("Text (AnswerText caunt)").GetComponent<Text>();
    }
    private void Update()
    {
        if (_enabledCanvas == true)
        {
            _canvasQuestion.SetActive(true);
        }
        else if (_enabledCanvas == false) 
        {
            _canvasQuestion.SetActive(false);
        }
        QuestionText();
    }
    void QuestionText()
    {
        _questionText.text = _countScores.ToString();
    }
    public void CountPlus()
    {
        _countScores++;
        _enabledCanvas = false;
        
    }
    public void CountMinus()
    {
        _countScores--;
        if (_countScores <= 0 )
        {
            _countScores = 0;
            _enabledCanvas = false;
        }
        _enabledCanvas = false;
    }
}
