using UnityEngine;

public class QuanLySound : MonoBehaviour
{
    // Các AudioSource để quản lý các âm thanh khác nhau
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource collectionSound;

    public void PlayJumpSound()
    {
        jumpSound.Play();
    }

    public void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void PlayCollectionSound()
    {
        collectionSound.Play();
    }
    // Phương thức để lấy độ dài clip deathSound
    public float GetDeathClipLength()
    {
        return deathSound.clip.length;
    }
}
