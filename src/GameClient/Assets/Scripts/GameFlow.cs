using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private Canvas _winCanvas;
    [SerializeField]
    private Canvas _loseCanvas;
    [SerializeField]
    private float _timeToWin;

    public void OnGameWin()
    {
        Invoke(nameof(ShowGameWin), _timeToWin);
    }

    private void ShowGameWin()
    {
        _winCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
