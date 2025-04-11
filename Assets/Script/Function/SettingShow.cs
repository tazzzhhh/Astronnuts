using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingScreen; // Tham chiếu đến Settings Screen
    [SerializeField] private GameObject mainMenuScreen; // Tham chiếu đến Main Menu Screen

    

    public GameObject panel; // Tham chiếu đến Panel


    public void OpenSettings()
    {
        settingScreen.SetActive(true); // Hiển thị SettingScreen
        panel.transform.Find("Play").gameObject.SetActive(false); // Ẩn nút Play
        panel.transform.Find("Setting").gameObject.SetActive(false); // Ẩn nút Setting
        panel.transform.Find("Information").gameObject.SetActive(false); // Ẩn nút Information
        panel.transform.Find("Contact").gameObject.SetActive(false); //Ẩn nút Contact

    }

    public void CloseSettings()
    {
        settingScreen.SetActive(false); // Ẩn SettingScreen
        panel.transform.Find("Play").gameObject.SetActive(true); // Hiển thị nút Play
        panel.transform.Find("Setting").gameObject.SetActive(true); // Hiển thị nút Setting
        panel.transform.Find("Information").gameObject.SetActive(true); // Hiện nút Information
        panel.transform.Find("Contact").gameObject.SetActive(true); // Hiện nút Contact
    }

}
