using UnityEngine;

public class CameraLookAtMe : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
