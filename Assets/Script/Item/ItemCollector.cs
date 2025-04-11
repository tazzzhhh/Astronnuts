using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int cherries = 0;
    public static int apples = 0;

    [SerializeField] private Text cherriestext;
    [SerializeField] private Text applestext;
    public AudioManager audioManager;          // Tham chiếu đến AudioManager



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriestext.text = "" + cherries;
            // Phát âm thanh thu thập qua AudioManager
            if (audioManager != null && audioManager.collection != null)
            {
                audioManager.PlaySFX(audioManager.collection);
            }
        }

        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            apples++;
            applestext.text = "" + apples;

            if (audioManager != null && audioManager.collection != null)
            {
                audioManager.PlaySFX(audioManager.collection);
            }
        }
    }
}