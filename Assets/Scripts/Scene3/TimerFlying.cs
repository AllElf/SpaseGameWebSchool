using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TimerFlying : MonoBehaviour
{
    public float _time = 300f;
    [SerializeField] Text _text;
    [SerializeField] public bool stopTime;

    private void Start()
    {
        stopTime = false;
        StartTimer();
    }
    public void StartTimer()
    {
        StartCoroutine(TimerLevel());
    }

    IEnumerator TimerLevel()
    {
        while (!stopTime)
        {
            yield return new WaitForSecondsRealtime(1f);
            _time--;
            _text.text = "Timer: " + _time.ToString() + " second";
            if (_time <= 0)
            {
                StopCoroutine(TimerLevel());
                break;

            }
        }
    }
}
