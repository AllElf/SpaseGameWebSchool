using System.Collections;
using UnityEngine;

public class ListOfResources : MonoBehaviour
{
    public GameObject[] _resourcesObject;
    public GameObject _resourceObject;

    private void Start()
    {
        StartCoroutine(RandomResource());
    }

    public void Corutines()
    {
        StartCoroutine(RandomResource());
    }
    IEnumerator RandomResource()
    {
        _resourceObject = _resourcesObject[Random.Range(0, _resourcesObject.Length)];
        yield return new WaitForSeconds(0);
        StopAllCoroutines();
    }
}
