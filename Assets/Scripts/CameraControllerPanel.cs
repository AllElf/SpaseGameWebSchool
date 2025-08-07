using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraControllerPanel : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] ColliderEnterDrag _colliderEnterDrag;
    [SerializeField] Rigidbody rb;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float jump;
    [SerializeField] MyJoystick _myJoystick;
    public float moveSpeedJoystick;

    public bool pressed = false;
    public int _fingerId;

    [SerializeField] Text _text;
    [SerializeField] GameObject _head;
    [SerializeField] GameObject _body;
    [SerializeField] GameObject _eyesCamera;
    [SerializeField] Camera m_Camera;
    [SerializeField] Text m_Text;
    public float sensitivity = 1.0f;
    public float sensitivityPanelRotate = 0.3f; // Чувствительность мыши
    public float maxYAngle = 45.0f; // Максимальный угол вращения по вертикали
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    float mouseX = 0;
    float mouseY = 0;

    void Start()
    {
        _myJoystick = GameObject.FindObjectOfType<MyJoystick>();
        _colliderEnterDrag = GameObject.Find("Hand").GetComponent<ColliderEnterDrag>();
        m_Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _text = GameObject.Find("Text (Debug)").GetComponent<Text>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Коснулся");
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
 
    private void FixedUpdate()
    {
        IndexTouch();
        IndexText();
        _eyesCamera.transform.position = _head.transform.position;
            if (pressed == true)
            {
                foreach (Touch touch in Input.touches) // Цикл Косания в Ввод.касания
                {
                    if (touch.fingerId == _fingerId) // Если палец равен тому что равен _fingerId
                    {
                        if (touch.phase == TouchPhase.Moved) // Если мы двигаем по сенсору то
                        {
                            mouseY = touch.deltaPosition.y * sensitivityPanelRotate;
                            mouseX = touch.deltaPosition.x * sensitivityPanelRotate;
                            // Вращаем персонажа в горизонтальной плоскости
                            m_Camera.transform.Rotate(Vector3.up * mouseX * sensitivity);

                            // Вращаем камеру в вертикальной плоскости
                            rotationY += mouseY * sensitivity;
                            rotationX += mouseX * sensitivity;
                            rotationY = Mathf.Clamp(rotationY, -maxYAngle, maxYAngle);
                            m_Camera.transform.localRotation = Quaternion.Euler(rotationY, -rotationX, 0);
                            _body.transform.localRotation = Quaternion.Euler(0, -rotationX, 0);
                            _head.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

                        }

                        if (touch.phase == TouchPhase.Stationary) //Если мы не двигаем по сенсору то
                        {
                            mouseY = 0;
                            mouseX = 0;
                        }
                    }
                }
            }
        
        else
        {
            mouseX = Input.GetAxis("Mouse X") * sensitivity;
            mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        }  
    }

    void IndexText()
    {
        if (pressed == true)
        {
            m_Text.text = "True";
        }
        else if (pressed == false)
        {
            m_Text.text = "False";
        }
    }
    void IndexTouch()
    {

        if(pressed == true && _fingerId == 0)
        {
            _myJoystick._fingerIdJoystick = 1;
            _text.text = "_fingerId = " + _fingerId.ToString();
        }
        else if (_myJoystick._pressedJoystick == true && _myJoystick._fingerIdJoystick == 0)
        {
            _fingerId = 1;
            _text.text = "_fingerId = " + _fingerId.ToString();
        }
        else
        {
            _myJoystick._fingerIdJoystick = 0;
            _fingerId = 0;
            _text.text = "_0 and 0";
        }
    }
    public void Jump()
    {
        if(_colliderEnterDrag._noJump ==  false)
        {
            Vector3 vec = new Vector3(0, jump * 10f, 0);
            rb.AddForce(vec);
        }
        
    }
}
