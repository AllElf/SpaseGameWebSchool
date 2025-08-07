using UnityEngine;

public class SendHTTP : MonoBehaviour
{
    [SerializeField] WriteToFileFlying writeToFileFlying;

    private void OnEnable()
    {
        writeToFileFlying.Http();
    }
}
