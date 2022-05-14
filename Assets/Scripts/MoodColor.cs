using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoodColor : MonoBehaviour
{
    public void ToggleDayMode(bool modeOn)
    {
        this.GetComponent<TextMeshProUGUI>().color = modeOn
            ? new Color(13f / 255f, 84f / 255f, 72f / 255f)
            : new Color(255f / 255f, 255f / 255f, 255f / 255f);
    }
}
