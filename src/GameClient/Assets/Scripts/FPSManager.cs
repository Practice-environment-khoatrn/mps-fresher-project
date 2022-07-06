using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class FPSManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _fpsText;

    private readonly StringBuilder _stringBuilder = new StringBuilder();
    private readonly WaitForSeconds _waitFor1Sec = new WaitForSeconds(1);

    private void Start()
    {
        StartCoroutine(MeasureFPS());
    }

    private IEnumerator MeasureFPS()
    {
        while (true)
        {
            _stringBuilder.Clear();
            int prevFrameCount = Time.frameCount;
            yield return _waitFor1Sec;
            int currFrameCount = Time.frameCount;
            int fps = currFrameCount - prevFrameCount;
            _stringBuilder.Append(fps);
            _fpsText.text = _stringBuilder.ToString();
        }
    }
}
