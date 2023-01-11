using System;
using UnityEngine;

public class CustomTimer : MonoBehaviour
{
    #region Fields

    public float CurrentValue { get => _timeValue; }

    [SerializeField] private float _timeValue = 0;

    private bool _isOn;

    #endregion

    #region Events

    public event Action<string> TimeChanged;

    #endregion

    #region Methods

    private void FixedUpdate()
    {
        if (_isOn)
        {
            _timeValue += Time.deltaTime;
            TimeChanged?.Invoke(_timeValue.ToString("F2"));
        }
    }

    public void StartTimer() => _isOn = true;
    public void StopTimer() => _isOn = false;
    public void ResetTimer() => _timeValue = 0;
    #endregion
}
