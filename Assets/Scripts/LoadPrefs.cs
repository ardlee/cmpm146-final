using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [SerializeField] private bool canUse = false;
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;


    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("asterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
        }
    }
}
