using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    #region Fields
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _resultsText;
    [SerializeField] private Text _hint;

    private IList<string> _resultsToDisplay = new List<string>();

    #endregion

    #region Methods
    private void OnEnable()
    {
        var _timer = FindObjectOfType<CustomTimer>();
        if (_timer != null)
            _timer.TimeChanged += OnTimeChaged;
        
        var _timerController = FindObjectOfType<TimerController>();
        if (_timerController != null)
            _timerController.StopButtonPressed += AddNewItem;

        var _startButton = FindObjectOfType<StartButton>();
        if (_startButton != null)
        {
            _startButton.PlayerArrived += ShowHint;
            _startButton.PlayerLeft += HideHint;
        }
    }

    private void ShowHint() => _hint.gameObject.SetActive(true);
    private void HideHint() => _hint.gameObject.SetActive(false);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void AddNewItem(string newResult)
    {
        if (string.IsNullOrEmpty(newResult))
            return;

        _resultsToDisplay.Add(newResult);
        _resultsText.text = string.Empty;

        if (_resultsToDisplay.Count > 10)
            _resultsToDisplay.RemoveAt(0);

        _resultsText.text += "Results \n";
        _resultsToDisplay.ToList().ForEach(x => _resultsText.text += $"{x}\n");
    }

    private void OnTimeChaged(string value)
    { 
        if (!string.IsNullOrEmpty(value))
            _timerText.text = value;
    }

    private void OnDisable()
    {
        var _timer = FindObjectOfType<CustomTimer>();
        if (_timer != null)
            _timer.TimeChanged -= OnTimeChaged;

        var _timerController = FindObjectOfType<TimerController>();
        if (_timerController != null)
            _timerController.StopButtonPressed -= AddNewItem;

        var _startButton = FindObjectOfType<StartButton>();
        if (_startButton !=null)
        {
            _startButton.PlayerArrived -= ShowHint;
            _startButton.PlayerLeft -= HideHint;
        }
    }
    #endregion
}
