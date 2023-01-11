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
    public void ShowHint() => _hint.gameObject.SetActive(true);
    public void HideHint() => _hint.gameObject.SetActive(false);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AddNewItem(string newResult)
    {
        if (string.IsNullOrEmpty(newResult))
            return;

        _resultsToDisplay.Add(newResult);
        _resultsText.text = string.Empty;

        if (_resultsToDisplay.Count > 10)
            _resultsToDisplay.RemoveAt(0);

        _resultsText.text += "Results: \n";
        _resultsToDisplay.ToList().ForEach(x => _resultsText.text += $"{x}\n");
    }

    public void OnTimeChaged(string value)
    { 
        if (!string.IsNullOrEmpty(value))
            _timerText.text = value;
    }
    #endregion
}
