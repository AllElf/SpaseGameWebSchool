using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleFlying : MonoBehaviour
{
    public GameObject _canvas;
    [SerializeField] Image _image;
    [SerializeField] Text _text;
    OnEnableQuestion _onEnableQuestion;
    [SerializeField] bool _enabled;
    [SerializeField] float _second = 1f;
    public float _halfMinute = 30f;

    private void Start()
    {
        _canvas.SetActive(false);
        TimeGameReal();
    }
    public void TimeGameNull()
    {
        Time.timeScale = 0;
    }
    public void TimeGameReal()
    {
        Time.timeScale = 1f;
    }
    [Obsolete]
    public void Ñycle()
    {
        _second = 1f;
        _halfMinute = 30;
        StartCoroutine(Second());
        _enabled = true;
        Time.timeScale = 0;
    }
    [Obsolete]
    public void Realtime()
    {
        Time.timeScale = 1;
        StartCoroutine(Second());
    }
    [Obsolete]
    IEnumerator Second()
    {
        while (_second > 0f)
        {
            if (_canvas.active == false)
            {
                _second = 1f;
                _halfMinute = 30;
                StopCoroutine(Second());
                break;
            }
            yield return new WaitForSecondsRealtime(1f);
            _halfMinute--;
            _text.text = _halfMinute.ToString();
            _second -= 0.0333333333f;
            _image.fillAmount = _second;
            if (_second <= 0f)
            {
                _enabled = false;
                Time.timeScale = 1;
                _canvas.SetActive(false);
                StopCoroutine(Second());
                break;
            }
            
        }
    }
}
