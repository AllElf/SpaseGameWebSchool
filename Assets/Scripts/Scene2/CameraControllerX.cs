using UnityEngine;

public class CameraControllerX : MonoBehaviour
{
    [SerializeField] GameObject _rayObject;
    [SerializeField] float lookSpeed = 2.0f;
    [SerializeField] float lookXLimit = 45.0f;
    float rotationX = 0, rotationY = 0;

    private void Start()
    {
        _rayObject = GameObject.FindGameObjectWithTag("RayPC");
    }
    void Update()
    {
        MouseController();
    }
    
    void MouseController()
    {
        rotationY += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX += -Input.GetAxis("Mouse X") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(rotationY * lookSpeed, -rotationX * lookSpeed, 0);
        if (Input.GetMouseButton(1))
        {
            _rayObject.transform.rotation = transform.rotation;
        }
        

    }
}
