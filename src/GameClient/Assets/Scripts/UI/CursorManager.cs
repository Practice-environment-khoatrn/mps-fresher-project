using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private bool _isMouseOnScreen;

    private void Start()
    {
        Cursor.lockState = _isMouseOnScreen ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
