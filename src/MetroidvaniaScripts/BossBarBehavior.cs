using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBarBehavior : MonoBehaviour
{
    public static BossBarBehavior Instance { get; private set; }

    private Image mask;

    private float originalSize;
    private void Awake()
    {
        Instance = this;
        mask = GetComponent<Image>();
        originalSize = mask.rectTransform.rect.width;
    }
    /// <summary>
    /// Modifies boss's health bar
    /// </summary>
    /// <param name="value"></param>
    public void ChangeHealthBar(float value)
    {

        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value * originalSize);
    }
}
