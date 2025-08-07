using System;
using UnityEngine;

public class OnEnableQuestion : MonoBehaviour
{
    [SerializeField] TimeScaleFlying _timeScaleFlying;
    [Obsolete]
    private void OnEnable()
    {
        _timeScaleFlying = GameObject.FindObjectOfType<TimeScaleFlying>();
        _timeScaleFlying.Ñycle();
    }
    [Obsolete]
    private void OnDisable()
    {
        _timeScaleFlying.Realtime();
    }

}
