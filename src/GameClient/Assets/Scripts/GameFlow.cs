using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private Canvas _pauseCanvas;
    [SerializeField]
    private Canvas _winCanvas;
    [SerializeField]
    private Canvas _loseCanvas;
    [SerializeField]
    private float _timeToWin;

    private void Start()
    {
        OnGamePause();
    }

    public void OnGameWon()
    {
        Invoke(nameof(ShowGameWon), _timeToWin);
    }

    private void ShowGameWon()
    {
        _winCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnGameLost()
    {
        _loseCanvas.gameObject.SetActive(true);
    }

    public void OnGamePause()
    {
        Time.timeScale = 0;
        _pauseCanvas.gameObject.SetActive(true);
    }

    public void OnGameContinue()
    {
        Time.timeScale = 1;
        _pauseCanvas.gameObject.SetActive(false);
    }
}
