using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    [SerializeField] private GameObject buttonleft;
    [SerializeField] private GameObject buttonright;
    [SerializeField] private GameObject buttonjump;
    [SerializeField] private GameObject GameOverScreen;

    [SerializeField] private Text cherryText;
    [SerializeField] private Text appleText;

    public static int cherrysolan = 0;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        isGameOver = false;        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ItemCollector.cherries = 0; //Reset số lượng cherry
        ItemCollector.apples = 0; //Reset số lượng apple

    }

    public void MainMenuGame()
    {
        SceneManager.LoadScene("Start Scenes");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        // Kích hoạt màn hình Game Over
        gameOverScreen.SetActive(true);

        // Ẩn các nút điều khiển
        buttonleft.SetActive(false);
        buttonright.SetActive(false);
        buttonjump.SetActive(false);

        //Hiển thị và cập nhật số cherry đã ăn đc
        cherryText.text = ": " + ItemCollector.cherries;

        //Hiển thị và cập nhật số cherry đã ăn đc
        appleText.text = ": " + ItemCollector.apples;


        // Đặt trạng thái game over
        isGameOver = true;
    }
}
