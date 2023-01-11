using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    private Player _player;
    private TimerController _timerController;
    private UI _ui;
    private StartButton _startButton;
    private CustomTimer _timer;
    private InputManager _input;
    #endregion

    #region Methods
    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _timerController = FindObjectOfType<TimerController>();
        _ui = FindObjectOfType<UI>();
        _startButton = FindObjectOfType<StartButton>();
        _timer = FindObjectOfType<CustomTimer>();
         _input = FindObjectOfType<InputManager>();

        if (_input != null || _timerController)
            _input.TimerButtonPressed += _timerController.ChangeTimerMode;

        if (_player != null && _timerController != null)
            _timerController.FinalButtonPressed += _player.BackToStart;

        if (_timer != null || _ui != null)
            _timer.TimeChanged += _ui.OnTimeChaged;

        if (_timerController != null || _ui != null)
            _timerController.StopButtonPressed += _ui.AddNewItem;

        if (_startButton != null || _ui != null)
        {
            _startButton.PlayerArrived += _ui.ShowHint;
            _startButton.PlayerLeft += _ui.HideHint;
        }
    }

    private void OnDisable()
    {
        if (_input != null || _timerController)
            _input.TimerButtonPressed -= _timerController.ChangeTimerMode;

        if (_player != null && _timerController != null)
            _timerController.FinalButtonPressed -= _player.BackToStart;

        if (_timer != null || _ui != null)
            _timer.TimeChanged -= _ui.OnTimeChaged;

        if (_timerController != null || _ui != null)
            _timerController.StopButtonPressed -= _ui.AddNewItem;


        if (_startButton != null || _ui != null)
        {
            _startButton.PlayerArrived -= _ui.ShowHint;
            _startButton.PlayerLeft -= _ui.HideHint;
        }
    }
    #endregion
}
