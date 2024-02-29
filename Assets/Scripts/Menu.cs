using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


/*https://www.youtube.com/watch?v=8kVeDbuqokU&ab_channel=Zenva
 * https://www.youtube.com/watch?v=Cq_Nnw_LwnI&ab_channel=SpeedTutor
 * https://www.youtube.com/watch?v=XiJ-kb-NvV4&ab_channel=JTAGames
*/
public class Menu : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    //[SerializeField] private Slider volumeSlider = null;

    //[Header("Confirmation")]
    //[SerializeField] private GameObject comfirmationPrompt = null;
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //StartCoroutine(ConfirmationBox());
    }


}
