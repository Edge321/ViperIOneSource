using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public static HealthBarBehavior Instance { get; private set; }

    private Image mask;

    private float originalSize;
    private void Awake()
    {
        Instance = this;
        mask = GetComponent<Image>();
        originalSize = mask.rectTransform.rect.height;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
    }
    /// <summary>
    /// Modifies player's health bar
    /// </summary>
    /// <param name="value"></param>
    public void ChangeHealthBar(float value)
    {

        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize - (value * originalSize));
    }
}
