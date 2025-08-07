using UnityEngine;
using UnityEngine.EventSystems;


public class JoysitcController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Rigidbody rb;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float jump;
    [SerializeField] bool pressed;
    [SerializeField] float _fingerId = 0;
    [SerializeField] float _horizontal, _vertical;
    public float moveSpeedJoystick;


    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
    private void FixedUpdate()
    {
        if (pressed == true)
        {
            rb.linearVelocity = new Vector3(joystick.Horizontal * moveSpeedJoystick, rb.linearVelocity.y, joystick.Vertical * moveSpeedJoystick);
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                rb.transform.rotation = Quaternion.LookRotation(rb.linearVelocity.normalized);

            }
        }
        else if (pressed == false)
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            rb.linearVelocity = new Vector3(_horizontal * moveSpeedJoystick, rb.linearVelocity.y, _vertical * moveSpeedJoystick);
            if (_horizontal != 0 || _vertical != 0)
            {
                rb.transform.rotation = Quaternion.LookRotation(rb.linearVelocity.normalized);

            }
        }
    }
    public void Jump()
    {
        Vector3 vec = new Vector3(0, jump, 0);
        rb.AddForce(vec);
    }

}     
