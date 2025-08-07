using UnityEngine;

public class FolowObj : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject player;

    private void Update()
    {
        obj.transform.position = player.transform.position;
    }

}
