using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject _player;
    [SerializeField] Rigidbody _rigidbody;

    public float _fingerIdJoystick;
    public bool _pressedJoystick = false;


    [SerializeField] float _horizontal, _vertical;
    [SerializeField] float _MouseX, _MouseY;
    [SerializeField] float _speed;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rigidbody = _player.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (_pressedJoystick == true)
        {
            foreach (Touch touch in Input.touches) // ���� ������� � ����.�������
            {
                if (touch.fingerId == _fingerIdJoystick) // ���� ����� ����� ���� ��� ����� _fingerId
                {
                    if (touch.phase == TouchPhase.Moved) // ���� �� ������� �� ������� ��
                    {
                        _vertical += touch.deltaPosition.y * _speed;
                        _horizontal += touch.deltaPosition.x * _speed;
                        _rigidbody.AddRelativeForce(-_horizontal, _rigidbody.linearVelocity.y, -_vertical);
                        }

                    if (touch.phase == TouchPhase.Stationary) //���� �� �� ������� �� ������� ��
                    {
                        _vertical += touch.deltaPosition.y * _speed;
                        _horizontal += touch.deltaPosition.x * _speed;
                        _rigidbody.AddRelativeForce(-_horizontal, _rigidbody.linearVelocity.y, -_vertical);
                    }
                }
            }
        }

        else
        {
            _vertical = 0;
            _horizontal = 0;
            _horizontal = Input.GetAxis("Mouse X") * _speed;
            _vertical = Input.GetAxis("Mouse Y") * _speed;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("�������� ������");
        _pressedJoystick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressedJoystick = false;
    }
}
