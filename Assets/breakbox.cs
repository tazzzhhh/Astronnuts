using UnityEngine;
using System.Collections; // Thêm namespace để sử dụng Coroutine

public class breakbox : MonoBehaviour
{
    public Sprite[] brokenPieceSprites; // Mảng chứa các sprite của mảnh vỡ
    public float explosionForce = 5f; // Lực để các mảnh vỡ bay ra
    public float breakDelay = 1f; // Thời gian delay trước khi hộp vỡ (mặc định là 1 giây)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu player chạm vào box
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player đã đứng lên box!");
            StartCoroutine(BreakBoxWithDelay()); // Bắt đầu Coroutine với delay
        }
    }

    private IEnumerator BreakBoxWithDelay()
    {
        Debug.Log("Chờ " + breakDelay + " giây trước khi hộp vỡ...");

        // Tạm dừng trong khoảng thời gian breakDelay
        yield return new WaitForSeconds(breakDelay);

        Debug.Log("Box đang bị phá hủy!");

        // Tạo các mảnh vỡ từ sprite
        foreach (var pieceSprite in brokenPieceSprites)
        {
            // Tạo một đối tượng mới từ sprite
            GameObject brokenPiece = new GameObject("BrokenPiece");
            brokenPiece.transform.position = transform.position;

            // Thêm SpriteRenderer và đặt sprite
            SpriteRenderer spriteRenderer = brokenPiece.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = pieceSprite;

            // Thêm Rigidbody2D để xử lý vật lý
            Rigidbody2D rb = brokenPiece.AddComponent<Rigidbody2D>();

            // Thêm Collider2D (ví dụ: BoxCollider2D)
            BoxCollider2D collider = brokenPiece.AddComponent<BoxCollider2D>();

            // Áp dụng lực ngẫu nhiên để các mảnh vỡ bay ra
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(0.5f, 1f);
            Vector2 randomDirection = new Vector2(randomX, randomY).normalized;
            rb.AddForce(randomDirection * explosionForce, ForceMode2D.Impulse);
        }

        // Phá hủy box
        Destroy(gameObject);
    }
}