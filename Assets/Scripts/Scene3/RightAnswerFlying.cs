using Unity.VisualScripting;
using UnityEngine;

public class RightAnswerFlying : MonoBehaviour
{
    [SerializeField] CanvasQuestionScript _canvasQuestionScript;
    [SerializeField] TimeScaleFlying _timeScaleFlying;
    RaycastHit _hit;


    private void Start()
    {
        _canvasQuestionScript = GameObject.FindObjectOfType<CanvasQuestionScript>();
        _timeScaleFlying = GameObject.FindObjectOfType<TimeScaleFlying>();
    }

    private void Update()
    {
        if(_timeScaleFlying._halfMinute <= 1)
        {
            _canvasQuestionScript.CountMinus();
            Destroy(gameObject);
            _timeScaleFlying._canvas.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            RayCast();
        }

    }
    void RayCast()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
        {
            if (_hit.collider.tag == "Minus")
            {
                _canvasQuestionScript.CountMinus();
                Destroy(gameObject);
            }
            else if (_hit.collider.tag == "Plus")
            {
                _canvasQuestionScript.CountPlus();
                Destroy(gameObject);
            }
        }
    }
}
