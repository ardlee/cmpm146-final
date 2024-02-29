using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;

    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    public float defaultBrightness = 1.0f; // Default brightness level

    AutoExposure exposure;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            //this function keeps the brightness level to the game scene
            //without it only the menu brightness would change
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
    void Start()
    {
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", defaultBrightness);
        brightnessSlider.value = savedBrightness;
        brightness.TryGetSettings(out exposure);
        AdjustBrightness(brightnessSlider.value);
    }

    public void SetBrightness(float brightness)
    {
        // Set the brightness level
        AdjustBrightness(brightnessSlider.value);

        // Save the brightness level to PlayerPrefs
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }

    public void AdjustBrightness(float value)
    {
        if(value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }
}
