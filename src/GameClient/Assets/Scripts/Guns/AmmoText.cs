using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    [SerializeField]
    private GunAmmo _gunAmmo;
    [SerializeField]
    private TMP_Text _ammoText;

    private readonly StringBuilder _ammoStringBuilder = new StringBuilder();

    private void Update()
    {
        _ammoStringBuilder.Clear();
        _ammoStringBuilder.Append(_gunAmmo.LoadedAmmo);
        _ammoText.text = _ammoStringBuilder.ToString();
    }
}
