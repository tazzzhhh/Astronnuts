using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public Button[] buttons; //tạo mảng button giữ các nút cấp độ
    public GameObject levelButton; //tạo mảng tên là levelButton 

    private void Awake()
    {
        ButtonToArray();
        
        int mokhoalevel = PlayerPrefs.GetInt("UnlockedLevel", 1); //đặt gt mặc định là 1 -> level mặc định là level 1
        for(int i = 0; i < buttons.Length; i++) //for dùng vô hiệu hóa các nút level
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i < mokhoalevel; i++)//for để kích hoạt lại các nút = số cấp đã đc mở khóa
        {
            buttons[i].interactable = true;
        }
    }



    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId; //khi click vào màn nào -> chọn đúng màn đó
        SceneManager.LoadScene(levelName); //dùng loadscene để hiển thị level đã chọn
    }

    public void ButtonToArray()//tạo hàm ButtonToArray
    {
        int childCount = levelButton.transform.childCount;//kích thước của mảng button = số lg đối tượng con của levelButtons
        buttons = new Button[childCount];

        for(int i = 0; i < childCount; i++)//for chỉ định thành phần nút của đối tượng con của đối tg levelButtons
        {
            buttons[i] = levelButton.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }   
    
    public void CloseLevel()
    {
        this.gameObject.SetActive(false);
    }
}
