using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] Vector3 rotateVector = new Vector3(0, 1, 0);
    private void FixedUpdate()
    {
        transform.Rotate(rotateVector);
    }
}
