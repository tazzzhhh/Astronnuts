using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundbat;
    [SerializeField] Image soundtat;
    private bool chon = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else 
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = chon;
    }

    public void Nhannut() // Tạo hàm để tắt bật âm thanh của game
    {
        if(chon == false) // Nếu click -> âm thanh game sẽ được bật
        {
            chon = true;
            AudioListener.pause = true;
        }
        else // Ngược lại, khi click mà âm thanh có -> âm thanh game sẽ tắt
        {
            chon = false;
            AudioListener.pause = false;
        }

        Luu();
        UpdateButtonIcon();
    }

    private void Load()
    {
        chon = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Luu()
    {
        PlayerPrefs.SetInt("muted", chon ? 1 : 0);   
    }

    private void UpdateButtonIcon()
    {
        if(chon == false)
        {
            soundbat.enabled = true;
            soundtat.enabled = false;
        }
        else
        {
            soundbat.enabled = false;
            soundtat.enabled = true;
        }
    }
}
