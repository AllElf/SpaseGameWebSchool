using UnityEngine;
using UnityEngine.UI;

public class Scene2Controller : MonoBehaviour
{
    [SerializeField] CanvasQuestionScript _canvasQuestionScript;
    PersonalData _personalData;
    [SerializeField] Text _text;
    public string _personalDataOne;
    public float _counsTwoScene;
    [SerializeField] bool _send;




    void Start()
    {
        // Получение значения переменной
        string data = GameManager.Instance.dataToTransfer;
        float score = GameManager.InstanceScore.scoreToTransfer;
        //_personalData._studentPersonalData = data + score.ToString();
        _personalDataOne = data + score.ToString();
        _text.text = data + score.ToString();
        _send = false;
        Debug.Log("Data from previous scene: " + data + score.ToString());
    }
    private void Update()
    {
        _counsTwoScene = _canvasQuestionScript._countScores;
        
    }
}