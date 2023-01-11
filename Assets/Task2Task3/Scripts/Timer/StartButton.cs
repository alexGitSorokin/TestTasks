using System;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    #region Properties
    public event Action PlayerArrived;
    public event Action PlayerLeft;
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        PlayerArrived?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerLeft?.Invoke();
    }
    #endregion
}
