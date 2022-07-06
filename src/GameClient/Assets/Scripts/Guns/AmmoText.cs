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

    private string[] _ammoStrings;

    private void Start()
    {
        InitializeAmmoStrings();
    }

    private void InitializeAmmoStrings()
    {
        int magazineSize = _gunAmmo.GetMagazineSize();
        _ammoStrings = new string[magazineSize + 1];
        for (int i = 0; i < magazineSize + 1; i++)
        {
            _ammoStrings[i] = i.ToString();
        }
    }

    private void Update()
    {
        _ammoText.text = _ammoStrings[_gunAmmo.LoadedAmmo];
    }
}
