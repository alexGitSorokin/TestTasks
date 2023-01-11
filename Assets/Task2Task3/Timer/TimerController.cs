using System;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    #region Fields
    [SerializeField] private CustomTimer _timer;

    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _StopButton;

    private const float RADIUS_INTERRACTION = 3;
    #endregion

    #region Properties

    public event Action<string> StopButtonPressed;
    public event Action FinalButtonPressed;

    #endregion


    #region Methods
    private void OnEnable()
    {
        var _input = FindObjectOfType<InputManager>();
        if (_input != null)
            _input.TimerButtonPressed += ChangeTimerMode;
    }

    private void Start()
    {
        _timer = FindObjectOfType<CustomTimer>();
    }

    public void ChangeTimerMode()
    {
        var playerPostition = Player.Instance.transform.position;
        var startButtonPosition = _startButton.transform.position;
        var stopButtonPosition = _StopButton.transform.position;

        if (Vector3.Distance(startButtonPosition, playerPostition) < RADIUS_INTERRACTION)
            StartTimer();
        else if (Vector3.Distance(stopButtonPosition, playerPostition) < RADIUS_INTERRACTION)
            StopTimer();
    }

    public void StartTimer()
    {
        _timer.StartTimer();
    }

    public void StopTimer()
    {
        _timer.StopTimer();
        StopButtonPressed?.Invoke(_timer.CurrentValue.ToString("F2"));
        _timer.ResetTimer();
        FinalButtonPressed?.Invoke();
    }

    private void OnDisable()
    {
        var _input = FindObjectOfType<InputManager>();
        if (_input != null)
            _input.TimerButtonPressed -= ChangeTimerMode;
    }
    #endregion
}
