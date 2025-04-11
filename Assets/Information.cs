using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject informationScreen;

    public GameObject panel; // Tham chiếu đến Panel


    public void OpenInformation()
    {
        informationScreen.SetActive(true);
        panel.transform.Find("Play").gameObject.SetActive(false); // Ẩn nút Play
        panel.transform.Find("Setting").gameObject.SetActive(false); // Ẩn nút Setting 
        panel.transform.Find("Information").gameObject.SetActive(false); // Ẩn nút Information
        panel.transform.Find("Contact").gameObject.SetActive(false); // Ẩn nút Contact
    }

    public void CloseInformation()
    {
        informationScreen.SetActive(false); // Ẩn SettingScreen
        panel.transform.Find("Play").gameObject.SetActive(true); // Hiển thị nút Play
        panel.transform.Find("Setting").gameObject.SetActive(true); // Hiển thị nút Setting
        panel.transform.Find("Information").gameObject.SetActive(true); // Hiển thị nút Information
        panel.transform.Find("Contact").gameObject.SetActive(true); // Hiện nút Contact
    }
}
