using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer settingMixer; //gọi hàm settingmixer
    [SerializeField] private Slider musicslider; //gọi hàm thanh trượt slider cho music 
    [SerializeField] private Slider spxslider; //gọi hàm thanh trượt slider cho spx


    private void Start() //lệnh tương thích giữa mixer và slider
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            Loadvolume();
        }
        else 
        {
            SetMusicvolume();
            SetSpxvolume();
        }
    }

    public void SetMusicvolume() //lệnh tinh chỉnh hàm music thông qua slider của music
    {
        float volume = musicslider.value;
        settingMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }


    public void SetSpxvolume() //lệnh tinh chỉnh hàm music thông qua slider của music
    {
        float volume = spxslider.value;
        settingMixer.SetFloat("SPX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SPXVolume", volume);
    }

    private void Loadvolume() 
    {
        musicslider.value = PlayerPrefs.GetFloat("musicVolume");
        spxslider.value = PlayerPrefs.GetFloat("SPXVolume");
        SetMusicvolume();
        SetSpxvolume();
    }
}
