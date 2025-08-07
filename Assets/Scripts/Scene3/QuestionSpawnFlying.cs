using System.Collections;
using UnityEngine;

public class QuestionSpawnFlying : MonoBehaviour
{
    /*"Questions/PanelQuestion1";*/
    [SerializeField] string[] _wayQuestions;
    [SerializeField] GameObject[] _questionPrefab;
    [SerializeField] RectTransform _pointPanelQuestions;
    [SerializeField] CanvasQuestionScript _canvasQuestionScript;
    [SerializeField] Scene2Controller _scene2Controller;
    [SerializeField] GameObject _pref;
    [SerializeField] GameObject _CanvasGameOver;

    [SerializeField] int _count = 10;

    private void Start()
    {
        _scene2Controller = GameObject.FindObjectOfType<Scene2Controller>();
        _questionPrefab = new GameObject[_wayQuestions.Length];
        _count = _wayQuestions.Length;
        for (int i = 0; i < _wayQuestions.Length; i++)
        {
            _questionPrefab[i] = Resources.Load<GameObject>(_wayQuestions[i]);
        }
        _canvasQuestionScript = GetComponent<CanvasQuestionScript>();
        StartCoroutine(QuestionNumber());
    }
   IEnumerator QuestionNumber()
    {
        for(_count = 9; _count > -1; _count--)
        {
            yield return new WaitForSeconds(10f);
            _canvasQuestionScript._enabledCanvas = true;
            _pref = Instantiate(_questionPrefab[_count], _pointPanelQuestions.position, _pointPanelQuestions.rotation, _pointPanelQuestions);
            if(_count <= -1)
            {
                if(_scene2Controller._counsTwoScene > 10)
                {
                    _CanvasGameOver.SetActive(true);
                    StopCoroutine(QuestionNumber());
                    Time.timeScale = 0f;
                }
                else
                {
                    StopCoroutine(QuestionNumber());
                }
            }
        } 
    }
}
