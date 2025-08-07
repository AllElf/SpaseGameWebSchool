using UnityEngine;

public class RightAnswer : MonoBehaviour
{
    CanvasQuestionScript _canvasQuestionScript;
    RaycastHit _hit;
    public ParticlesChest _particlesChestAnswer;


    private void Start()
    {
        _canvasQuestionScript = GameObject.FindObjectOfType<CanvasQuestionScript>();
    }

    private void FixedUpdate()
    {
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
                _particlesChestAnswer.DeleteObject();
                Destroy(gameObject);
            }
            else if (_hit.collider.tag == "Plus")
            {
                _canvasQuestionScript.CountPlus();
                _particlesChestAnswer.DeleteObject();
                Destroy(gameObject);
            }
        }
    }
}
