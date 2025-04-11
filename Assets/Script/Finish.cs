using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        // Tìm đối tượng AudioManager trong Scene
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }

        // Kiểm tra giá trị mặc định nếu cần
        if (!PlayerPrefs.HasKey("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", 1);
        }

        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
        }
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Phát âm thanh 'finish' từ AudioManager
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.finish);
            }

            // Thực hiện logic hoàn thành cấp độ
            StartCoroutine(HandleFinish());
        }
    }

    private IEnumerator HandleFinish()
    {
        // Chờ một chút để âm thanh phát trước khi chuyển cảnh
        if (audioManager != null && audioManager.finish != null)
        {
            yield return new WaitForSeconds(audioManager.finish.length);
        }

        CompleteLevel();
    }

    private void CompleteLevel()
    {
        MoKhoaLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void MoKhoaLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1); // khi đến đích -> tăng gt reachedindex + 1
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1); // tăng unlockedlevel +1
            PlayerPrefs.Save();
        }
    }
}
