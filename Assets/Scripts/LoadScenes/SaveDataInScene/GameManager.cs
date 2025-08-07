using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static GameManager InstanceScore { get; private set; }

    public float scoreToTransfer; // Переменная для передачи числовых данных
    public string dataToTransfer; // Переменная для передачи текстовых данных
    [SerializeField] CanvasQuestionScript canvasQuestionScript;
    [SerializeField] PersonalData personalData;
    private void Start()
    {
        // Проверка на наличие экземпляра
        if (Instance != null && Instance != this)
        {
            if (InstanceScore != null && InstanceScore != this)
            {
                Destroy(gameObject);
            }
                
        }
        else
        {
            Instance = this;
            InstanceScore = this;
            DontDestroyOnLoad(gameObject); // Сохранение объекта при загрузке новой сцены
        }
    }

    private void FixedUpdate()
    {
        if (canvasQuestionScript != null) 
        {
            Instance.scoreToTransfer = canvasQuestionScript._countScores;
            Instance.dataToTransfer = personalData._studentPersonalData;
        }
    }
}