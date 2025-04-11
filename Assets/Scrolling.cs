using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [Header("Background Settings")]
    [SerializeField] private RawImage imgsky;
    [SerializeField] private float _x = 0.1f;
    [SerializeField] private float _y = 0f;

    [Header("Enable/Disable Scrolling")]
    public bool isScrollingEnabled = true;

    private void Update()
    {
        if (!isScrollingEnabled || imgsky == null)
            return;

        imgsky.uvRect = new Rect(imgsky.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, imgsky.uvRect.size);
    }

    private void OnDisable()
    {
        // Khi bị disable (chuyển scene, tắt canvas...), reset về mặc định để tránh bị nhòe
        if (imgsky != null)
        {
            imgsky.uvRect = new Rect(Vector2.zero, imgsky.uvRect.size);
        }
    }

    private void OnEnable()
    {
        // Cũng reset lại khi vừa được bật lên
        if (imgsky != null)
        {
            imgsky.uvRect = new Rect(Vector2.zero, imgsky.uvRect.size);
        }
    }
}
