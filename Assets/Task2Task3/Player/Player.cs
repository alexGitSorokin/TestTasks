using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject _startPosition;
    #endregion

    #region Properties
    public static Player Instance { get; private set; }
    #endregion

    #region Methods
    private void Awake() => Instance = this;

    private void OnEnable()
    {
        var timerController = FindObjectOfType<TimerController>();
        if (timerController != null)
            timerController.FinalButtonPressed += BackToStart;
    }

    private void BackToStart()
    {
        if (_startPosition != null)
        {
            CharacterController _controller = FindObjectOfType<CharacterController>();
            _controller.enabled = false;
            transform.position = _startPosition.transform.position;
            _controller.enabled = true;
        }
    }

    private void OnDisable()
    {
        var timerController = FindObjectOfType<TimerController>();
        if (timerController != null)
            timerController.FinalButtonPressed -= BackToStart;
    }
    #endregion
}
