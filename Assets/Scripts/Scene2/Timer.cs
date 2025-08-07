using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float _time = 120f;
    [SerializeField] Text _text;
    [SerializeField] MovePoints _movePoints;

    private void Start()
    {
        _movePoints = FindObjectOfType<MovePoints>();
        _text = GameObject.Find("Text (Timer)").GetComponent<Text>();
       
    }
    public void StartTimer()
    {
        StartCoroutine(TimerLevel());
    }

    IEnumerator TimerLevel()
    {
        while (_time >= 0)
        {
            yield return new WaitForSeconds(1f);
            _time--;
            _text.text = "Таймер: " + _time.ToString() + " секунд";
            if (_time == 0)
            {
                _movePoints._heathPlayer = 0f;
                StopCoroutine(TimerLevel());
                break;
                
            }
        }
    }
}
