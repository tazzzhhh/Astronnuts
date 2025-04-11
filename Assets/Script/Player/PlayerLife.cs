using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isDead;

    public GameManagerScript gameManagerScript; // Tham chiếu đến GameManagerScript
    public AudioManager audioManager;          // Tham chiếu đến AudioManager

    [SerializeField] private GameObject pauseButton; // Nút Pause cần ẩn
    [SerializeField] private GameObject cherriesImage; // Ẩn hình trái cherries

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (audioManager == null)
        {
            Debug.LogError("AudioManager chưa được gán trong PlayerLife!");
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player chạm vào Trap!");

        // Đặt trạng thái chết
        isDead = true;

        // Dừng chuyển động
        rb.bodyType = RigidbodyType2D.Static;

        // Kích hoạt animation chết
        anim.SetTrigger("death");

        // Tắt nhạc nền qua AudioManager
        if (audioManager != null)
        {
            audioManager.StopBackgroundMusic();
        }
        else
        {
            Debug.LogError("Không tìm thấy AudioManager để tắt nhạc nền!");
        }

        // Phát âm thanh chết qua AudioManager
        if (audioManager != null && audioManager.death != null)
        {
            audioManager.PlaySFX(audioManager.death);
        }

        // Ẩn Pause Button nếu có
        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }

        if (cherriesImage != null) 
        {
            cherriesImage.SetActive(false);
        }

        // Gọi Coroutine để xử lý Game Over sau khi âm thanh kết thúc
        StartCoroutine(HandleGameOver());
    }

    private IEnumerator HandleGameOver()
    {
        if (audioManager != null && audioManager.death != null)
        {
            yield return new WaitForSeconds(audioManager.death.length);
        }

        Debug.Log("Hiển thị Game Over!");
        gameManagerScript.GameOver();
    }
}
