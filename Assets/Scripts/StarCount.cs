using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] public int countStar;
    [SerializeField] public AudioSource sourceStare;

    private void Start()
    {
        StartCoroutine(Count());
    }
    IEnumerator Count()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            text.text = countStar.ToString();
        }
    }
}
