using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetter : MonoBehaviour
{
    private PlayerInformation pi;

    private void OnValidate()
    {
        pi = GetComponent<PlayerInformation>();
    }

    private void Start()
    {
        Debug.Log($"player: {pi.player.name}");
    }
}
