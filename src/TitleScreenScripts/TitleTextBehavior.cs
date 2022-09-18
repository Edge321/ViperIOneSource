using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextBehavior : MonoBehaviour
{
    private Text titleText;

    //Color values set to pure white
    private Color transparentColor = new Color(255, 255, 255, 0);
    private Color opaqueColor = new Color(255, 255, 255, 255);

    private float switchColorTimer = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        titleText = GetComponent<Text>();
        titleText.color = transparentColor;
        InvokeRepeating("SwitchTextTransparency", 0, switchColorTimer);
    }
    /// <summary>
    /// Switches text color be either be transparent or opaque
    /// </summary>
    private void SwitchTextTransparency()
    {
        if(titleText.color == transparentColor)
        {
            titleText.color = opaqueColor;
        }
        else if (titleText.color == opaqueColor)
        {
            titleText.color = transparentColor;
        }
    }
}
